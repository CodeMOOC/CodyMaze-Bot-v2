using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WaitingForDirection)]
    public class WaitingForDirectionProcessor : BaseStateProcessor {

        public WaitingForDirectionProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<WaitingForDirectionProcessor> logger
        ) : base(conversation, bot, logger) {

        }

        private Direction? DirectionFromQuery(string s) {
            return s switch {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => null
            };
        }

        public override async Task<bool> Process(Update update) {
            if (update.CallbackQuery == null) {
                return false;
            }

            var dir = DirectionFromQuery(update.CallbackQuery.Data);
            if(dir == null) {
                return false;
            }

            if(!GridCoordinate.TryParse(Conversation.CurrentUser.PartialCoordinate, out var coord)) {
                Logger.LogError("Received direction without partial coordinate");
                // TODO say something?
                return false;
            }
            var finalCoord = new GridCoordinate(coord.ColumnIndex, coord.RowIndex, dir);

            await HandleArrivalOn(update, finalCoord);

            return true;
        }

    }
}
