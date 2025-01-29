using Net.Codecrete.QrCodeGenerator;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WomPlatform.Connector;
using WomPlatform.Connector.Models;
using Color = SixLabors.ImageSharp.Color;
using RectangleF = SixLabors.ImageSharp.RectangleF;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WomGeneration)]
    public class WomGenerationProcessor : BaseStateProcessor {

        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public WomGenerationProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            MazeGenerator mazeGenerator,
            IConfiguration configuration,
            ILogger<WomGenerationProcessor> logger,
            ILoggerFactory loggerFactory
        ) : base(conversation, bot, mazeGenerator, logger) {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public override Task<bool> Process(Update update) {
            return Task.FromResult(true);
        }

        public override async Task HandleStateEntry(Update update) {
            var confWom = _configuration.GetRequiredSection("Wom");
            var womSourceId = confWom["SourceId"];
            var womPrivateKeyPath = confWom["PrivateKeyPath"];
            var womDomain = confWom["Domain"];

            using var womPrivateKeyStream = new FileStream(womPrivateKeyPath, FileMode.Open);

            await Bot.SendMessage(
                Conversation.TelegramId,
                Strings.WomGenerationProcessing,
                parseMode: ParseMode.Html,
                linkPreviewOptions: new LinkPreviewOptions { IsDisabled = true }
            );

            var wom = new Client(womDomain, _loggerFactory);
            var womSource = wom.CreateInstrument(womSourceId, womPrivateKeyStream);
            var womVoucherRequest = await womSource.RequestVouchers(new VoucherCreatePayload.VoucherInfo {
                Aim = "C",
                Count = 30,
                CreationMode = VoucherCreatePayload.VoucherCreationMode.SetLocationOnRedeem,
                Timestamp = DateTime.UtcNow,
            });

            var qrCode = QrCode.EncodeText(womVoucherRequest.Link, QrCode.Ecc.Low);
            using var outputImage = new Image<Rgba32>(300, 300, Color.White.ToPixel<Rgba32>());
            DrawQrCode(outputImage, qrCode);

            var outputStream = new MemoryStream();
            await outputImage.SaveAsJpegAsync(outputStream);
            outputStream.Position = 0;

            await Bot.SendPhoto(
                Conversation.TelegramId,
                new InputFileStream(outputStream),
                caption: string.Format(Strings.WomGenerationCaption, womVoucherRequest.Password),
                parseMode: ParseMode.Html
            );

            await Bot.SendMessage(
                Conversation.TelegramId,
                string.Format(Strings.WomGenerationResult, womVoucherRequest.Link, womVoucherRequest.Password),
                parseMode: ParseMode.Html,
                linkPreviewOptions: new LinkPreviewOptions { IsDisabled = true }
            );

            await Conversation.SetState((int)BotState.GameComplete);
        }

        private void DrawQrCode(Image<Rgba32> outputImage, QrCode qrCode) {
            if (outputImage.Width != outputImage.Height) {
                throw new ArgumentException("QR Code must be drawn in a squared format");
            }

            outputImage.Mutate(ctx => {
                var solidBlack = Brushes.Solid(Color.Black);

                var blockSize = (outputImage.Width - 40) / (float)qrCode.Size;
                for (int r = 0; r < qrCode.Size; ++r) {
                    for (int c = 0; c < qrCode.Size; ++c) {
                        if (qrCode.GetModule(c, r)) {
                            ctx.Fill(solidBlack, new RectangleF(20 + (c * blockSize), 20 + (r * blockSize), blockSize, blockSize));
                        }
                    }
                }
            });
        }
    }
}
