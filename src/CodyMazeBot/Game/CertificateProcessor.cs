using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
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
                            using (var certStream = GenerateCertificate(name, DateTime.UtcNow, Conversation.ActiveEvent)) {
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

        private PrivateFontCollection AddFonts(params string[] fonts) {
            var collection = new PrivateFontCollection();
            var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var font in fonts) {
                collection.AddFontFile(Path.Combine(root, "Resources", font));
            }
            return collection;
        }

        private FontFamily GetFontFamily(PrivateFontCollection collection, string preferredName, int preferredIndex) {
            var families = collection.Families;
            if(families.Length == 0) {
                return FontFamily.GenericSansSerif;
            }

            var family = Array.Find(families, f => f.Name.Equals(preferredName, StringComparison.InvariantCultureIgnoreCase));
            if(family != null) {
                return family;
            }

            if(preferredIndex < families.Length) {
                return families[preferredIndex];
            }

            return families[0];
        }

        private Stream GenerateCertificate(string name, DateTime today, Event evt) {
            using var backgroundStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("CodyMazeBot.Resources.certificate-background.jpg");
            var output = Image.FromStream(backgroundStream);

            using (var gfx = Graphics.FromImage(output)) {
                using var fontCollection = AddFonts("Montserrat-ExtraBold.ttf", "Montserrat-Light.ttf", "Montserrat-Medium.ttf");

                Logger.LogInformation("Loaded {0} custom font families: {1}", fontCollection.Families.Length, string.Join(',', from f in fontCollection.Families select f.Name));

                var fontFamilyLight = GetFontFamily(fontCollection, "Montserrat Light", 1);
                var fontFamilyMedium = GetFontFamily(fontCollection, "Montserrat Medium", 2);
                var fontFamilyBold = GetFontFamily(fontCollection, "Montserrat ExtraBold", 0);

                var fontHeader = new Font(fontFamilyLight ?? FontFamily.GenericSansSerif, 56f, GraphicsUnit.Pixel);
                var fontName = new Font(fontFamilyBold ?? FontFamily.GenericSansSerif, 90f, FontStyle.Bold, GraphicsUnit.Pixel);
                var fontDescription = new Font(fontFamilyMedium ?? FontFamily.GenericSansSerif, 56f, GraphicsUnit.Pixel);
                var fontSmall = new Font(fontFamilyLight ?? FontFamily.GenericSansSerif, 40f, GraphicsUnit.Pixel);

                gfx.DrawString(Strings.CertificateGenerationTitle,
                    fontHeader, Brushes.DarkGray,
                    new RectangleF(512, 580, 1024, 120), new StringFormat {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Near
                    });
                gfx.DrawString(name, fontName, Brushes.Black,
                    new RectangleF(160, 695, 1728, 250), new StringFormat {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Near
                    });
                gfx.DrawString((evt?.Title).CanLocalize() ?
                        string.Format(Strings.CertificateGenerationDescriptionEvent, evt.Title.Localize()) :
                        Strings.CertificateGenerationDescriptionPlain,
                    fontDescription, Brushes.Black,
                    new RectangleF(160, 870, 1728, 320), new StringFormat {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near
                    });
                gfx.DrawString(string.Format("{0} {1}.", Strings.CertificateGenerationReleasedOn, today.ToString(Strings.CertificateGenerationReleaseDateFormat)),
                    fontSmall, Brushes.DarkGray,
                    new RectangleF(160, 1000, 1728, 1463 - 1000 - 160), new StringFormat {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Far
                    });
            }

            var outputStream = new MemoryStream();
            output.Save(outputStream, ImageFormat.Jpeg);
            outputStream.Seek(0, SeekOrigin.Begin);
            return outputStream;
        }

    }
}
