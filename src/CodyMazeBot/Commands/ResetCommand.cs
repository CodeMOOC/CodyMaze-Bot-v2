using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Commands {
    public class ResetCommand : ICommand {

        private readonly Conversation _conversation;
        private readonly ITelegramBotClient _bot;

        public ResetCommand(
            Conversation conversation,
            ITelegramBotClient bot
        ) {
            _conversation = conversation;
            _bot = bot;
        }

        public async Task<(BotState? NewState, bool ShortCircuit)> ProcessCommand(Update update) {
            await _conversation.ResetGame();

            await _bot.SendMessage(_conversation.TelegramId, Strings.ResetCommandOk, parseMode: ParseMode.Html);

            return (null, true);
        }
    }
}
