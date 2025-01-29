using Microsoft.Extensions.Logging;
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
        private readonly ILogger<StartCommand> _logger;

        public StartCommand(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<StartCommand> logger
        ) {
            _conversation = conversation;
            _bot = bot;
            _logger = logger;
        }

        public async Task<(BotState? NewState, bool ShortCircuit)> ProcessCommand(Update update) {
            string payload = update.Message.Text[6..].Trim();

            if (string.IsNullOrEmpty(payload)) {
                // Direct /start command
                await _bot.SendMessage(update.Message.Chat.Id, Strings.StartCommand, parseMode: ParseMode.Html);
                return (null, true);
            }
            else {
                // Interpret the payload as "[eventCode-]coord"
                (var eventCode, var coordCode) = ExtractFromPayload(payload);
                if(!string.IsNullOrEmpty(eventCode)) {
                    _logger.LogDebug("Extracted event code '{0}' from start code", eventCode);
                    await _conversation.SetEventCode(eventCode);
                }

                if (GridCoordinate.TryParse(coordCode, out var coord)) {
                    _logger.LogDebug("Incoming grid coordinate {0}", coord);
                    _conversation.IncomingCoordinate = coord;
                    return (null, false);
                }
                else {
                    _logger.LogDebug("Unable to parse coordinate {0}", coordCode);
                    await _bot.SendMessage(update.Message.Chat.Id, Strings.StartCommandCoordInvalid, parseMode: ParseMode.Html);
                    return (null, true);
                }
            }
        }

        private static (string EventCode, string Coordinate) ExtractFromPayload(string payload) {
            int hyphenIndex = payload.LastIndexOf('-');
            if (hyphenIndex >= 0) {
                return (payload[..hyphenIndex], payload[(hyphenIndex+1)..]);
            }
            else {
                return (null, payload);
            }
        }

    }
}
