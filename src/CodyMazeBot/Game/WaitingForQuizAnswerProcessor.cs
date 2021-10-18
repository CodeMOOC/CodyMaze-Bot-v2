using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WaitingForQuizAnswer)]
    public class WaitingForQuizAnswerProcessor : BaseStateProcessor {

        public WaitingForQuizAnswerProcessor(
            Conversation conversation,
            ITelegramBotClient bot
        ) : base(conversation, bot) {

        }

        public override async Task Process(Update update) {
            await Bot.SendTextMessageAsync(update.Message.Chat.Id, "Waiting for answer");
        }

    }
}
