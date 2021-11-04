using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public enum BotState : int {
        WaitingForLocation = 0,
        WaitingForDirection = 1,
        WaitingForQuizAnswer = 5,
        SetLanguage = 10,
        Questionnaire = 30,
        CertificateGeneration = 50,
        GameComplete = 999
    }
}
