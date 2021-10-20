using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

                        using var certStream = GenerateCertificate(name, DateTime.UtcNow, Conversation.ActiveEvent);

                        await Bot.SendPhotoAsync(Conversation.TelegramId,
                            certStream,
                            caption: Strings.CertificateGenerationCaption,
                            parseMode: ParseMode.Html
                        );

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

        private Stream GenerateCertificate(string name, DateTime today, Event evt) {
            using var backgroundStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("CodyMazeBot.Resources.certificate-background.jpg");
            var output = Bitmap.FromStream(backgroundStream);

            using (var gfx = Graphics.FromImage(output)) {
                var fontMedium = new Font(FontFamily.GenericSansSerif, 42f, GraphicsUnit.Pixel);
                var fontName = new Font(FontFamily.GenericSansSerif, 90f, FontStyle.Bold, GraphicsUnit.Pixel);
                var fontDescription = new Font(FontFamily.GenericSansSerif, 42f, GraphicsUnit.Pixel);
                var fontSmall = new Font(FontFamily.GenericSansSerif, 36f, GraphicsUnit.Pixel);

                gfx.DrawString(Strings.CertificateGenerationTitle, fontMedium, Brushes.Black,
                    new RectangleF(512, 575, 1024, 120), new StringFormat {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Near
                    });
                gfx.DrawString(name, fontName, Brushes.Black,
                    new RectangleF(160, 690, 1728, 250), new StringFormat {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Near
                    });
                gfx.DrawString(Strings.CertificateGenerationDescription, fontDescription, Brushes.Black,
                    new RectangleF(160, 870, 1728, 320), new StringFormat {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Near
                    });
                gfx.DrawString(string.Format("{0} {1}", Strings.CertificateGenerationReleasedOn, today.ToString(Strings.CertificateGenerationReleaseDateFormat)),
                    fontSmall, Brushes.Black,
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
