using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CodyMazeBot.Commands {
    public interface ICommand {

        Task ProcessCommand(Update update);

    }
}
