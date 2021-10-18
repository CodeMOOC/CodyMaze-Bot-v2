using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public enum BotState : int {
        WaitingForLocation = 0,
        WaitingForQuizAnswer = 1,
        SetLanguage = 10
    }
}
