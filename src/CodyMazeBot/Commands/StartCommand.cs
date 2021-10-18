using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Commands {
    public class StartCommand : ICommand {

        private readonly Conversation _conversation;
        private readonly ITelegramBotClient _bot;

        public StartCommand(
            Conversation conversation,
            ITelegramBotClient bot
        ) {
            _conversation = conversation;
            _bot = bot;
        }

        public async Task<(BotState? NewState, bool ShortCircuit)> ProcessCommand(Update update) {
            string payload = update.Message.Text[6..].Trim();

            if(string.IsNullOrEmpty(payload)) {
                // Direct /start command
                await _bot.SendTextMessageAsync(update.Message.Chat.Id, Strings.StartCommand, parseMode: ParseMode.Html);
                return (null, true);
            }
            else {
                // This must be a coordinate
                if(GridCoordinate.TryParse(payload, out var coord)) {
                    _conversation.IncomingCoordinate = coord;
                    return (null, false);
                }
                else {
                    await _bot.SendTextMessageAsync(update.Message.Chat.Id, Strings.StartCommandCoordInvalid, parseMode: ParseMode.Html);
                    return (null, true);
                }
            }
        }

    }
}
