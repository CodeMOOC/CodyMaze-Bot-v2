using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.GameComplete)]
    public class GameCompleteProcessor : BaseStateProcessor {

        public GameCompleteProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<WaitingForQuizAnswerProcessor> logger
        ) : base(conversation, bot, logger) {

        }

        public override async Task HandleStateEntry(Update update) {
            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                Strings.GameComplete,
                parseMode: ParseMode.Html
            );
        }

        public override async Task<bool> Process(Update update) {
            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                Strings.GameCompletePrompt,
                parseMode: ParseMode.Html
            );

            return true;
        }

    }
}
