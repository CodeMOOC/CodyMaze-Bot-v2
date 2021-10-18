using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CodyMazeBot.Commands {
    public class LanguageCommand : ICommand {

        private readonly Conversation _conversation;
        private readonly ITelegramBotClient _bot;

        public LanguageCommand(
            Conversation conversation,
            ITelegramBotClient bot
        ) {
            _conversation = conversation;
            _bot = bot;
        }

        public async Task<(BotState? NewState, bool ShortCircuit)> ProcessCommand(Update update) {
            await _bot.SendTextMessageAsync(update.Message.Chat.Id, Strings.LanguageCommandAsk, ParseMode.Html,
                replyMarkup: new InlineKeyboardMarkup(new InlineKeyboardButton[] {
                    new InlineKeyboardButton { Text = "English", CallbackData = "en" },
                    new InlineKeyboardButton { Text = "Italiano", CallbackData = "it" },
                }));

            return (BotState.SetLanguage, true);
        }

    }
}
