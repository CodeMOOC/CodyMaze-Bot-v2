using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.Questionnaire)]
    public class QuestionnaireProcessor : BaseStateProcessor {

        public QuestionnaireProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<QuestionnaireProcessor> logger
        ) : base(conversation, bot, logger) {

        }

        public override async Task HandleStateEntry(Update update) {
            await Conversation.SetState((int)BotState.CertificateGeneration);
        }

        public override Task HandleStateExit(Update update) {
            return Task.CompletedTask;
        }

        public override Task<bool> Process(Update update) {
            return Task.FromResult(false);
        }

    }
}
