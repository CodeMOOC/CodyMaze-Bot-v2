using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WaitingForLocation)]
    public class WaitForLocationProcessor : BaseStateProcessor {

        public WaitForLocationProcessor(
            Conversation conversation,
            ITelegramBotClient bot
        ) : base(conversation, bot) {

        }

        public override async Task<bool> Process(Update update) {
            if(Conversation.IncomingCoordinate.HasValue) {
                
            }
            else {
                await update.DoWithChatId(chatId => {
                    return Bot.SendTextMessageAsync(chatId, "Waiting for location");
                });
            }
            return true;
        }

    }
}
