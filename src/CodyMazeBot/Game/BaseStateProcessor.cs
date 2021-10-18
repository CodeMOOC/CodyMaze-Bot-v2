using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Game {
    public abstract class BaseStateProcessor {

        protected Conversation Conversation { get; init; }
        protected ITelegramBotClient Bot { get; init; }

        public BaseStateProcessor(
            Conversation conversation,
            ITelegramBotClient bot
        ) {
            Conversation = conversation;
            Bot = bot;
        }

        public abstract Task<bool> Process(Update update);

        protected Task ReplyCannotHandle(Update update, string prompt = null) {
            string output = Strings.CannotHandle;
            if(!string.IsNullOrWhiteSpace(prompt)) {
                output += " " + prompt;
            }

            return Bot.SendTextMessageAsync(update.Message.Chat.Id, output, ParseMode.Html);
        }

    }
}
