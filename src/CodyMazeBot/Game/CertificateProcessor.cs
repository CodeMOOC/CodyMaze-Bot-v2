using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Logging;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WaitForCertificateName)]
    public class CertificateProcessor : BaseStateProcessor {

        public CertificateProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<WaitingForQuizAnswerProcessor> logger
        ) : base(conversation, bot, logger) {

        }

        private const string MemoryNameKey = "CertificateName";

        public override async Task<bool> Process(Update update) {
            if (update.Message != null) {
                var name = update.Message.Text.Trim();
                if (string.IsNullOrWhiteSpace(update.Message.Text) || name.Length < 3) {
                    await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        Strings.CertificateAskForNameInvalid,
                        parseMode: ParseMode.Html
                    );
                    return true;
                }

                await Conversation.SetMemory(MemoryNameKey, name);

                await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        string.Format(
                            Strings.CertificateAskForNameConfirmation,
                            name
                        ),
                        parseMode: ParseMode.Html,
                        replyMarkup: new InlineKeyboardMarkup(new InlineKeyboardButton[] {
                            new InlineKeyboardButton {
                                Text = Strings.ConfirmationYes,
                                CallbackData = "YES"
                            },
                            new InlineKeyboardButton {
                                Text = Strings.ConfirmationNo,
                                CallbackData = "NO"
                            }
                        })
                    );
            }
            else if(update.CallbackQuery != null) {
                string name = Conversation.GetMemory<string>(MemoryNameKey);
                if (name != null) {
                    if (update.CallbackQuery.Data == "YES") {
                        await Bot.SendTextMessageAsync(Conversation.TelegramId,
                            Strings.CertificateGenerationProcessing,
                            parseMode: ParseMode.Html
                        );

                        try {
                            using (var certStream = await GenerateCertificate(name, DateTime.UtcNow, Conversation.ActiveEvent)) {
                                await Bot.SendPhotoAsync(Conversation.TelegramId,
                                    certStream,
                                    caption: Strings.CertificateGenerationCaption,
                                    parseMode: ParseMode.Html
                                );
                            }
                        }
                        catch(Exception ex) {
                            Logger.LogError(ex, "Failed to generate certificate");
                            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                                Strings.CertificateGenerationError,
                                parseMode: ParseMode.Html
                            );
                        }

                        await Conversation.ClearMemory(MemoryNameKey);
                        await Conversation.SetState((int)BotState.GameComplete);
                    }
                    else {
                        await Bot.SendTextMessageAsync(Conversation.TelegramId,
                            Strings.CertificateAskForNameAgain,
                            parseMode: ParseMode.Html
                        );
                    }
                }
            }

            return true;
        }

        public override async Task HandleStateEntry(Update update) {
            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                Strings.Victory,
                parseMode: ParseMode.Html
            );

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                Strings.CertificateAskForName,
                parseMode: ParseMode.Html
            );
        }

        private FontCollection GetFonts() {
            var fonts = new string[] { "Montserrat-ExtraBold.ttf", "Montserrat-Light.ttf", "Montserrat-Medium.ttf" };
            var collection = new FontCollection();
            var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var font in fonts) {
                collection.Install(Path.Combine(root, "Resources", font));
            }
            return collection;
        }

        private const int CertificateMargin = 160;

        private async Task<Stream> GenerateCertificate(string name, DateTime today, Event evt) {
            using var backgroundStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("CodyMazeBot.Resources.certificate-background.jpg");
            using(var image = Image.Load(backgroundStream)) {
                var fonts = GetFonts();
                var fontFamilyLight = fonts.Find("Montserrat Light");
                var fontFamilyMedium = fonts.Find("Montserrat Medium");
                var fontFamilyBold = fonts.Find("Montserrat ExtraBold");

                var brushBlack = Brushes.Solid(Color.Black);
                var brushDarkGray = Brushes.Solid(Color.DarkGray);

                var width = image.Width;
                var height = image.Height;
                var centeredOptions = new DrawingOptions {
                    TextOptions = new TextOptions {
                        ApplyKerning = true,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        DpiX = (float)image.Metadata.HorizontalResolution,
                        DpiY = (float)image.Metadata.VerticalResolution
                    }
                };
                var wrappedOptions = new DrawingOptions {
                    TextOptions = new TextOptions {
                        ApplyKerning = true,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        WrapTextWidth = width - (CertificateMargin * 2),
                        DpiX = (float)image.Metadata.HorizontalResolution,
                        DpiY = (float)image.Metadata.VerticalResolution
                    }
                };
                var bottomOptions = new DrawingOptions {
                    TextOptions = new TextOptions {
                        ApplyKerning = true,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        DpiX = (float)image.Metadata.HorizontalResolution,
                        DpiY = (float)image.Metadata.VerticalResolution
                    }
                };

                image.Mutate(context => {
                    context.DrawText(centeredOptions, Strings.CertificateGenerationTitle,
                        new Font(fontFamilyMedium, 14f), brushDarkGray, new PointF(width / 2f, 580f));

                    context.DrawText(centeredOptions, name.Trim(),
                        new Font(fontFamilyBold, 28f), brushBlack, new PointF(width / 2f, 690f));

                    context.DrawText(
                        wrappedOptions,
                        (evt?.Title).CanLocalize() ?
                            string.Format(Strings.CertificateGenerationDescriptionEvent, evt.Title.Localize()) :
                            Strings.CertificateGenerationDescriptionPlain,
                        new Font(fontFamilyMedium, 14f), brushBlack, new PointF(CertificateMargin, 880f));

                    context.DrawText(
                        bottomOptions,
                        string.Format("{0} {1}.", Strings.CertificateGenerationReleasedOn, today.ToString(Strings.CertificateGenerationReleaseDateFormat)),
                        new Font(fontFamilyLight, 10f), brushDarkGray, new PointF(CertificateMargin, height - CertificateMargin));
                });

                var outputStream = new MemoryStream();
                await image.SaveAsJpegAsync(outputStream);
                outputStream.Seek(0, SeekOrigin.Begin);
                return outputStream;
            }
        }

    }
}
