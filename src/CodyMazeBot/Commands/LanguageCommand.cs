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
            await _bot.SendMessage(update.Message.Chat.Id, Strings.LanguageCommandAsk, parseMode: ParseMode.Html,
                replyMarkup: new InlineKeyboardMarkup(new InlineKeyboardButton[] {
                    new("English") { CallbackData = "en" },
                    new("Italiano") { CallbackData = "it" },
                }));

            return (BotState.SetLanguage, true);
        }

    }
}
