using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.GameComplete)]
    public class GameCompleteProcessor : BaseStateProcessor {

        public GameCompleteProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            MazeGenerator mazeGenerator,
            ILogger<WaitingForQuizAnswerProcessor> logger
        ) : base(conversation, bot, mazeGenerator, logger) {

        }

        public override async Task HandleStateEntry(Update update) {
            await Bot.SendMessage(Conversation.TelegramId,
                Strings.GameComplete,
                parseMode: ParseMode.Html
            );
        }

        public override async Task<bool> Process(Update update) {
            await Bot.SendMessage(Conversation.TelegramId,
                Strings.GameCompletePrompt,
                parseMode: ParseMode.Html
            );

            return true;
        }

    }
}
