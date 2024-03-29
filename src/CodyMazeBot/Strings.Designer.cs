﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodyMazeBot {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CodyMazeBot.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 👀 What direction are you facing?.
        /// </summary>
        public static string AcceptCoordinateWaitForDirection {
            get {
                return ResourceManager.GetString("AcceptCoordinateWaitForDirection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🟡.
        /// </summary>
        public static string AnswerCode1 {
            get {
                return ResourceManager.GetString("AnswerCode1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🟢.
        /// </summary>
        public static string AnswerCode2 {
            get {
                return ResourceManager.GetString("AnswerCode2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🔴.
        /// </summary>
        public static string AnswerCode3 {
            get {
                return ResourceManager.GetString("AnswerCode3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🔢 Execute the following instructions and scan the QR Code you stop on:
        ///
        ///&lt;code&gt;{0}&lt;/code&gt;.
        /// </summary>
        public static string AssignCode {
            get {
                return ResourceManager.GetString("AssignCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ❓ &lt;b&gt;{0}&lt;/b&gt;
        ///{1}
        ///
        ///🟡 {2}
        ///🟢 {3}
        ///🔴 {4}.
        /// </summary>
        public static string AssignQuiz {
            get {
                return ResourceManager.GetString("AssignQuiz", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, I don&apos;t understand..
        /// </summary>
        public static string CannotHandle {
            get {
                return ResourceManager.GetString("CannotHandle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 📃 &lt;b&gt;Certificate&lt;/b&gt;
        ///Send me a message with your full name, that will be put on the certificate of completion..
        /// </summary>
        public static string CertificateAskForName {
            get {
                return ResourceManager.GetString("CertificateAskForName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OK. Tell me your full name please..
        /// </summary>
        public static string CertificateAskForNameAgain {
            get {
                return ResourceManager.GetString("CertificateAskForNameAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your name is &lt;i&gt;“{0}”&lt;/i&gt;. Correct?.
        /// </summary>
        public static string CertificateAskForNameConfirmation {
            get {
                return ResourceManager.GetString("CertificateAskForNameConfirmation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to That nome doesn’t look right to me. Could you please write your full name?.
        /// </summary>
        public static string CertificateAskForNameInvalid {
            get {
                return ResourceManager.GetString("CertificateAskForNameInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your CodyMaze completion certificate.
        /// </summary>
        public static string CertificateGenerationCaption {
            get {
                return ResourceManager.GetString("CertificateGenerationCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to has successfully completed the “{0}” activity , interpreting sequences of instructions with repetition and selection constructs..
        /// </summary>
        public static string CertificateGenerationDescriptionEvent {
            get {
                return ResourceManager.GetString("CertificateGenerationDescriptionEvent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to has successfully completed the “Hour of Code” activity with CodyMaze, interpreting sequences of instructions with repetition and selection constructs..
        /// </summary>
        public static string CertificateGenerationDescriptionPlain {
            get {
                return ResourceManager.GetString("CertificateGenerationDescriptionPlain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🚨 Whoops, there was an error generating your certificate..
        /// </summary>
        public static string CertificateGenerationError {
            get {
                return ResourceManager.GetString("CertificateGenerationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ✒ Generating your certificate….
        /// </summary>
        public static string CertificateGenerationProcessing {
            get {
                return ResourceManager.GetString("CertificateGenerationProcessing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to D.
        /// </summary>
        public static string CertificateGenerationReleaseDateFormat {
            get {
                return ResourceManager.GetString("CertificateGenerationReleaseDateFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Released on.
        /// </summary>
        public static string CertificateGenerationReleasedOn {
            get {
                return ResourceManager.GetString("CertificateGenerationReleasedOn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Certificate of completion.
        /// </summary>
        public static string CertificateGenerationTitle {
            get {
                return ResourceManager.GetString("CertificateGenerationTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to else.
        /// </summary>
        public static string CodeElse {
            get {
                return ResourceManager.GetString("CodeElse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to f.
        /// </summary>
        public static string CodeForward {
            get {
                return ResourceManager.GetString("CodeForward", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if.
        /// </summary>
        public static string CodeIf {
            get {
                return ResourceManager.GetString("CodeIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to l.
        /// </summary>
        public static string CodeLeft {
            get {
                return ResourceManager.GetString("CodeLeft", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to no star.
        /// </summary>
        public static string CodeNoStar {
            get {
                return ResourceManager.GetString("CodeNoStar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to path ahead.
        /// </summary>
        public static string CodePathAhead {
            get {
                return ResourceManager.GetString("CodePathAhead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to path left.
        /// </summary>
        public static string CodePathLeft {
            get {
                return ResourceManager.GetString("CodePathLeft", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to path right.
        /// </summary>
        public static string CodePathRight {
            get {
                return ResourceManager.GetString("CodePathRight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to r.
        /// </summary>
        public static string CodeRight {
            get {
                return ResourceManager.GetString("CodeRight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to star.
        /// </summary>
        public static string CodeStar {
            get {
                return ResourceManager.GetString("CodeStar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to while.
        /// </summary>
        public static string CodeWhile {
            get {
                return ResourceManager.GetString("CodeWhile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No.
        /// </summary>
        public static string ConfirmationNo {
            get {
                return ResourceManager.GetString("ConfirmationNo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Yes.
        /// </summary>
        public static string ConfirmationYes {
            get {
                return ResourceManager.GetString("ConfirmationYes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ✔ &lt;b&gt;Correct!&lt;/b&gt;.
        /// </summary>
        public static string CorrectAnswer {
            get {
                return ResourceManager.GetString("CorrectAnswer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Very well! You&apos;re in the right spot ({0}) and you&apos;re looking {1}..
        /// </summary>
        public static string CorrectPosition {
            get {
                return ResourceManager.GetString("CorrectPosition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🚨 &lt;b&gt;Error&lt;/b&gt;
        ///I&apos;m terribly sorry, something went wrong. Please restart the game using the /reset command..
        /// </summary>
        public static string CriticalError {
            get {
                return ResourceManager.GetString("CriticalError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to East.
        /// </summary>
        public static string DirectionEast {
            get {
                return ResourceManager.GetString("DirectionEast", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to North.
        /// </summary>
        public static string DirectionNorth {
            get {
                return ResourceManager.GetString("DirectionNorth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to South.
        /// </summary>
        public static string DirectionSouth {
            get {
                return ResourceManager.GetString("DirectionSouth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to West.
        /// </summary>
        public static string DirectionWest {
            get {
                return ResourceManager.GetString("DirectionWest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to eastwards.
        /// </summary>
        public static string FacingEast {
            get {
                return ResourceManager.GetString("FacingEast", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to northwards.
        /// </summary>
        public static string FacingNorth {
            get {
                return ResourceManager.GetString("FacingNorth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to southwards.
        /// </summary>
        public static string FacingSouth {
            get {
                return ResourceManager.GetString("FacingSouth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to westwards.
        /// </summary>
        public static string FacingWest {
            get {
                return ResourceManager.GetString("FacingWest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;b&gt;You have completed the game.&lt;/b&gt; Thank you for playing! 🎖 Use the /reset command if you want to play again..
        /// </summary>
        public static string GameComplete {
            get {
                return ResourceManager.GetString("GameComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you want to play again? Use the /reset command..
        /// </summary>
        public static string GameCompletePrompt {
            get {
                return ResourceManager.GetString("GameCompletePrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🤖 Hi! I am the &lt;b&gt;CodyMaze bot&lt;/b&gt; and I will guide you through the game. The game is composed of &lt;b&gt;13 challenges&lt;/b&gt;: for each one, I will send you new instructions that you must follow exactly in order to reach the final destination on the game’s chessboard..
        /// </summary>
        public static string Help1 {
            get {
                return ResourceManager.GetString("Help1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In order to start playing, please scan the QR Code on one of the outer squares of the chessboard (that is, any square along the first or last row, or the first or last column). You may use any QR Code scanner application to do so..
        /// </summary>
        public static string Help2 {
            get {
                return ResourceManager.GetString("Help2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The instructions I will send you may contain the following commands:
        ///&lt;code&gt;f&lt;/code&gt;: move forward,
        ///&lt;code&gt;l&lt;/code&gt;: turn left,
        ///&lt;code&gt;r&lt;/code&gt;: turn right,
        ///and other commands such as &lt;code&gt;if&lt;/code&gt;, &lt;code&gt;else&lt;/code&gt;, and &lt;code&gt;while&lt;/code&gt;. Code blocks are indicated between braces (&lt;code&gt;{}&lt;/code&gt;) and can be repeated. For instance, &lt;code&gt;2{fr}&lt;/code&gt; tells you to move forward and turn right twice..
        /// </summary>
        public static string Help3 {
            get {
                return ResourceManager.GetString("Help3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Which language should I speak?.
        /// </summary>
        public static string LanguageCommandAsk {
            get {
                return ResourceManager.GetString("LanguageCommandAsk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sure!.
        /// </summary>
        public static string LanguageConfirm {
            get {
                return ResourceManager.GetString("LanguageConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank you! Your responses have been recorded..
        /// </summary>
        public static string QuestionnaireDone {
            get {
                return ResourceManager.GetString("QuestionnaireDone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 📝 &lt;b&gt;Questionnaire&lt;/b&gt;
        ///Before you leave, I have a couple of questions for you!.
        /// </summary>
        public static string QuestionnaireEntry {
            get {
                return ResourceManager.GetString("QuestionnaireEntry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, send me a message with the age as a number..
        /// </summary>
        public static string QuestionnaireErrorAgeInvalid {
            get {
                return ResourceManager.GetString("QuestionnaireErrorAgeInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to That number is a bit too high to be a valid age, I think..
        /// </summary>
        public static string QuestionnaireErrorAgeTooHigh {
            get {
                return ResourceManager.GetString("QuestionnaireErrorAgeTooHigh", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This doesn’t look like a valid age..
        /// </summary>
        public static string QuestionnaireErrorAgeTooLow {
            get {
                return ResourceManager.GetString("QuestionnaireErrorAgeTooLow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, answer to the question by clicking on one of the buttons..
        /// </summary>
        public static string QuestionnaireErrorAlternative {
            get {
                return ResourceManager.GetString("QuestionnaireErrorAlternative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please, send me a message with your answer to the question..
        /// </summary>
        public static string QuestionnaireErrorString {
            get {
                return ResourceManager.GetString("QuestionnaireErrorString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Let&apos;s start from the top! 👍 Scan one of the QR Codes on the outer squares of the chessboard to begin..
        /// </summary>
        public static string ResetCommandOk {
            get {
                return ResourceManager.GetString("ResetCommandOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🤖 Hello, I am the &lt;b&gt;CodyMaze bot&lt;/b&gt;! Please go to any of the grid’s outer squares and scan the QR Code you find there..
        /// </summary>
        public static string StartCommand {
            get {
                return ResourceManager.GetString("StartCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hmmm, the command you sent is not valid. Try scanning the CodyMaze QR Code again..
        /// </summary>
        public static string StartCommandCoordInvalid {
            get {
                return ResourceManager.GetString("StartCommandCoordInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 👏 Congratulations, you have completed CodyMaze!.
        /// </summary>
        public static string Victory {
            get {
                return ResourceManager.GetString("Victory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid start position: please go to any square of the grid&apos;s outer border and scan the QR Code you find there..
        /// </summary>
        public static string WaitForLocationFirstCoordinateWrong {
            get {
                return ResourceManager.GetString("WaitForLocationFirstCoordinateWrong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🧭 Please turn {0}..
        /// </summary>
        public static string WaitForLocationFirstSendDirection {
            get {
                return ResourceManager.GetString("WaitForLocationFirstSendDirection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ❌ You should be facing &lt;b&gt;{0}&lt;/b&gt;. Please confirm clicking on the buttons above..
        /// </summary>
        public static string WaitForLocationWrongDirection {
            get {
                return ResourceManager.GetString("WaitForLocationWrongDirection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 👋 Welcome to &lt;b&gt;{0}&lt;/b&gt;!.
        /// </summary>
        public static string WelcomeEventMessage {
            get {
                return ResourceManager.GetString("WelcomeEventMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🤖 Hello {0}, welcome to &lt;b&gt;{1}&lt;/b&gt;! Let&apos;s start the game..
        /// </summary>
        public static string WelcomeGame {
            get {
                return ResourceManager.GetString("WelcomeGame", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 👋 Welcome to &lt;b&gt;CodyMaze&lt;/b&gt;!.
        /// </summary>
        public static string WelcomeMessage {
            get {
                return ResourceManager.GetString("WelcomeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password: &lt;code&gt;{0}&lt;/code&gt;.
        /// </summary>
        public static string WomGenerationCaption {
            get {
                return ResourceManager.GetString("WomGenerationCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to But this is not all! I’m generating a &lt;b&gt;special prize&lt;/b&gt; for you….
        /// </summary>
        public static string WomGenerationProcessing {
            get {
                return ResourceManager.GetString("WomGenerationProcessing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Here you are! 🎖 Scan the QR Code above in order to obtain your &lt;a href=&quot;https://wom.social&quot;&gt;WOM vouchers&lt;/a&gt; as a prize for your efforts during the game!
        ///If you reading this on your smartphone, &lt;a href=&quot;{0}&quot;&gt;click here&lt;/a&gt; and use the following password: &lt;code&gt;{1}&lt;/code&gt;..
        /// </summary>
        public static string WomGenerationResult {
            get {
                return ResourceManager.GetString("WomGenerationResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ❌ &lt;b&gt;Wrong!&lt;/b&gt; Try again..
        /// </summary>
        public static string WrongAnswerTryAgain {
            get {
                return ResourceManager.GetString("WrongAnswerTryAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🚩 &lt;b&gt;Wrong move!&lt;/b&gt;
        ///Move back to position {0} and look {1}, then try executing the following instructions again:
        ///
        ///&lt;code&gt;{2}&lt;/code&gt;.
        /// </summary>
        public static string WrongMove {
            get {
                return ResourceManager.GetString("WrongMove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 🚩 &lt;b&gt;Wrong move!&lt;/b&gt;
        ///Move back to position {0} and look {1}, then try executing the instructions again..
        /// </summary>
        public static string WrongMoveWithoutCode {
            get {
                return ResourceManager.GetString("WrongMoveWithoutCode", resourceCulture);
            }
        }
    }
}
