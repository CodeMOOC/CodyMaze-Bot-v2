using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.SetLanguage)]
    public class SetLanguageProcessor : BaseStateProcessor {

        public SetLanguageProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<SetLanguageProcessor> logger
        ) : base(conversation, bot, logger) {

        }

        public override async Task<bool> Process(Update update) {
            if(update.CallbackQuery != null) {
                await Conversation.SetLanguage(update.CallbackQuery.Data);
                await Bot.SendTextMessageAsync(update.CallbackQuery.From.Id, Strings.LanguageConfirm, ParseMode.Html);

                return true;
            }

            return false;
        }
    }
}
