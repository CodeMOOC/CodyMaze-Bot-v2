using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WaitingForQuizAnswer)]
    public class WaitingForQuizAnswerProcessor : BaseStateProcessor {

        public WaitingForQuizAnswerProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            MazeGenerator mazeGenerator,
            ILogger<WaitingForQuizAnswerProcessor> logger
        ) : base(conversation, bot, mazeGenerator, logger) {

        }

        public override async Task<bool> Process(Update update) {
            if (update.CallbackQuery == null) {
                return false;
            }

            if(update.CallbackQuery.Data == "CORRECT") {
                Logger.LogInformation("Answer correct");

                await Bot.SendMessage(Conversation.TelegramId,
                    Strings.CorrectAnswer,
                    parseMode: ParseMode.Html
                );

                await AssignNextDestination(update);
            }
            else {
                Logger.LogInformation("Answer wrong");

                await Bot.SendMessage(Conversation.TelegramId,
                    Strings.WrongAnswerTryAgain,
                    parseMode: ParseMode.Html
                );

                // TODO: assign question again
            }

            return true;
        }

    }
}
