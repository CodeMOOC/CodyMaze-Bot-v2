using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Commands {
    public class HelpCommand : ICommand {

        private readonly Conversation _conversation;
        private readonly ITelegramBotClient _bot;

        public HelpCommand(
            Conversation conversation,
            ITelegramBotClient bot
        ) {
            _conversation = conversation;
            _bot = bot;
        }

        public async Task ProcessCommand(Update update) {
            await _bot.SendTextMessageAsync(update.Message.Chat.Id, Strings.Help1, parseMode: ParseMode.Html);
            await _bot.SendTextMessageAsync(update.Message.Chat.Id, Strings.Help2, parseMode: ParseMode.Html);
            await _bot.SendTextMessageAsync(update.Message.Chat.Id, Strings.Help3, parseMode: ParseMode.Html);
        }

    }
}
