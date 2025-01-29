using Telegram.Bot.Types;

namespace CodyMazeBot.Commands {
    public interface ICommand {

        Task<(BotState? NewState, bool ShortCircuit)> ProcessCommand(Update update);

    }
}
