using CodyMazeBot;

namespace MazeInstaller {
    internal interface IInstaller {
        Task Install(Storage storage);
    }
}
