using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CodyMazeBot {
    public static class BotExtensions {

        public static long? GetChatId(this Update update) {
            return update.Message?.From?.Id ??
                   update.CallbackQuery?.From?.Id
                   ;
        }

        public static Task DoWithChatId(this Update update, Func<long, Task> performer) {
            var chatId = update.GetChatId();
            if(chatId.HasValue) {
                return performer(chatId.Value);
            }
            else {
                return Task.CompletedTask;
            }
        }

    }
}
