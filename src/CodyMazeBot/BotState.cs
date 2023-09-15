namespace CodyMazeBot {
    public enum BotState : int {
        WaitingForLocation = 0,
        WaitingForDirection = 1,
        WaitingForQuizAnswer = 5,
        SetLanguage = 10,
        Questionnaire = 30,
        CertificateGeneration = 50,
        WomGeneration = 100,
        GameComplete = 999
    }
}
