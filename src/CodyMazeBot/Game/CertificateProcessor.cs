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
using Color = SixLabors.ImageSharp.Color;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.CertificateGeneration)]
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
                            new InlineKeyboardButton(Strings.ConfirmationYes) {
                                CallbackData = "YES"
                            },
                            new InlineKeyboardButton(Strings.ConfirmationNo) {
                                CallbackData = "NO"
                            }
                        })
                    );
            }
            else if (update.CallbackQuery != null) {
                string name = Conversation.GetMemory<string>(MemoryNameKey);
                if (name != null) {
                    if (update.CallbackQuery.Data == "YES") {
                        await Bot.SendTextMessageAsync(Conversation.TelegramId,
                            Strings.CertificateGenerationProcessing,
                            parseMode: ParseMode.Html
                        );

                        try {
                            using var certStream = await GenerateCertificate(name, DateTime.UtcNow, Conversation.ActiveEvent);

                            await Bot.SendPhotoAsync(Conversation.TelegramId,
                                new InputFileStream(certStream),
                                caption: Strings.CertificateGenerationCaption,
                                parseMode: ParseMode.Html
                            );
                        }
                        catch (Exception ex) {
                            Logger.LogError(ex, "Failed to generate certificate");
                            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                                Strings.CertificateGenerationError,
                                parseMode: ParseMode.Html
                            );
                        }

                        await Conversation.ClearMemory(MemoryNameKey);
                        await Conversation.SetState((int)BotState.WomGeneration);
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
                Strings.CertificateAskForName,
                parseMode: ParseMode.Html
            );
        }

        private FontCollection GetFonts() {
            var fonts = new string[] { "Montserrat-ExtraBold.ttf", "Montserrat-Light.ttf", "Montserrat-Medium.ttf" };
            var collection = new FontCollection();
            var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var font in fonts) {
                collection.Add(Path.Combine(root, "Resources", font));
            }
            return collection;
        }

        private Task<Stream> GenerateCertificate(string name, DateTime today, Event evt) {
            return evt?.Code switch {
                "neoconnessi" => GenerateNeoconnessiCertificate(name, today, evt),
                _ => GenerateDefaultCertificate(name, today, evt),
            };
        }

        private async Task<Stream> GenerateDefaultCertificate(string name, DateTime today, Event evt) {
            int CertificateMargin = 160;

            using var backgroundStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("CodyMazeBot.Resources.certificate-background.jpg");

            using (var image = Image.Load(backgroundStream)) {
                var fonts = GetFonts();
                var fontFamilyLight = fonts.Get("Montserrat Light");
                var fontFamilyMedium = fonts.Get("Montserrat Medium");
                var fontFamilyBold = fonts.Get("Montserrat ExtraBold");

                var brushBlack = Brushes.Solid(Color.Black);
                var brushDarkGray = Brushes.Solid(Color.DarkGray);

                var width = image.Width;
                var height = image.Height;

                image.Mutate(context => {
                    context.DrawText(new RichTextOptions(new Font(fontFamilyMedium, 14f)) {
                        Origin = new PointF(width / 2f, 580f),
                        KerningMode = KerningMode.Standard,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Dpi = (float)image.Metadata.HorizontalResolution,
                    }, Strings.CertificateGenerationTitle, brushDarkGray);

                    context.DrawText(new RichTextOptions(new Font(fontFamilyBold, 28f)) {
                        Origin = new PointF(width / 2f, 690f),
                        KerningMode = KerningMode.Standard,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Dpi = (float)image.Metadata.HorizontalResolution,
                    }, name.Trim(), brushBlack);

                    context.DrawText(new RichTextOptions(new Font(fontFamilyMedium, 14f)) {
                        Origin = new PointF(CertificateMargin, 880f),
                        KerningMode = KerningMode.Standard,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        WrappingLength = width - (CertificateMargin * 2),
                        Dpi = (float)image.Metadata.HorizontalResolution,
                    }, (evt?.Title).CanLocalize() ?
                        string.Format(Strings.CertificateGenerationDescriptionEvent, evt.Title.Localize()) :
                        Strings.CertificateGenerationDescriptionPlain,
                    brushBlack);

                    context.DrawText(new RichTextOptions(new Font(fontFamilyLight, 10f)) {
                        Origin = new PointF(CertificateMargin, height - CertificateMargin),
                        KerningMode = KerningMode.Standard,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Dpi = (float)image.Metadata.HorizontalResolution,
                    }, string.Format("{0} {1}.", Strings.CertificateGenerationReleasedOn, today.ToString(Strings.CertificateGenerationReleaseDateFormat)), brushDarkGray);
                });

                var outputStream = new MemoryStream();
                await image.SaveAsJpegAsync(outputStream);
                outputStream.Seek(0, SeekOrigin.Begin);
                return outputStream;
            }
        }

        private async Task<Stream> GenerateNeoconnessiCertificate(string name, DateTime today, Event evt) {
            int CertificateMargin = 94;
            int InnerMargin = 270;

            using var backgroundStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("CodyMazeBot.Resources.certificate-neoconnessi.jpg");

            using (var image = Image.Load(backgroundStream)) {
                var fonts = GetFonts();
                var fontFamilyLight = fonts.Get("Montserrat Light");
                var fontFamilyMedium = fonts.Get("Montserrat Medium");
                var fontFamilyBold = fonts.Get("Montserrat ExtraBold");

                var brushBlack = Brushes.Solid(Color.Black);
                var brushDarkGray = Brushes.Solid(Color.DarkGray);

                var width = image.Width;
                var height = image.Height;

                image.Mutate(context => {
                    context.DrawText(new RichTextOptions(new Font(fontFamilyBold, 64f)) {
                        Origin = new PointF(InnerMargin, 840f),
                        KerningMode = KerningMode.Standard,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Dpi = (float)image.Metadata.HorizontalResolution,
                    }, name.Trim(), brushBlack);

                    context.DrawText(new RichTextOptions(new Font(fontFamilyMedium, 25f)) {
                        Origin = new PointF(CertificateMargin + 266f, height - CertificateMargin),
                        KerningMode = KerningMode.Standard,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Dpi = (float)image.Metadata.HorizontalResolution,
                    }, string.Format("{0}.", today.ToString(Strings.CertificateGenerationReleaseDateFormat)), brushBlack);
                });

                var outputStream = new MemoryStream();
                await image.SaveAsJpegAsync(outputStream);
                outputStream.Seek(0, SeekOrigin.Begin);
                return outputStream;
            }
        }

    }
}
