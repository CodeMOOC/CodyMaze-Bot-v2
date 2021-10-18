using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CodyMazeBot.Commands {
    public interface ICommand {

        Task<(BotState? NewState, bool ShortCircuit)> ProcessCommand(Update update);

    }
}
