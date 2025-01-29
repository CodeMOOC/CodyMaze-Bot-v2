using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.Questionnaire)]
    public class QuestionnaireProcessor : BaseStateProcessor {

        public QuestionnaireProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            MazeGenerator mazeGenerator,
            ILogger<QuestionnaireProcessor> logger
        ) : base(conversation, bot, mazeGenerator, logger) {

        }

        private const string MemoryStateKey = "QuestionnaireIndex";
        private const string MemoryAnswerKey = "QuestionnaireAnswer";

        public override async Task HandleStateEntry(Update update) {
            if (Conversation.ActiveEvent == null ||
               Conversation.ActiveEvent.Questionnaire == null ||
               Conversation.ActiveEvent.Questionnaire.Questions == null ||
               Conversation.ActiveEvent.Questionnaire.Questions.Length == 0) {
                // No questionnaire to deliver, skip
                Logger.LogInformation("No questionnaire to present to user, skipping to certificate");
                await Conversation.SetState((int)BotState.CertificateGeneration);
                return;
            }

            await Bot.SendMessage(Conversation.TelegramId,
                Strings.QuestionnaireEntry,
                parseMode: ParseMode.Html
            );

            await Conversation.SetMemory(MemoryStateKey, 0);
            await DeliverQuestion(0);
        }

        public override async Task HandleStateExit(Update update) {
            if (Conversation.ActiveEvent == null ||
               Conversation.ActiveEvent.Questionnaire == null ||
               Conversation.ActiveEvent.Questionnaire.Questions == null ||
               Conversation.ActiveEvent.Questionnaire.Questions.Length == 0) {
                return;
            }

            await Bot.SendMessage(Conversation.TelegramId,
                Strings.QuestionnaireDone,
                parseMode: ParseMode.Html
            );

            var questionCount = Conversation.ActiveEvent.Questionnaire.Questions.Length;
            var answers = new string[questionCount];
            for (int i = 0; i < questionCount; ++i) {
                answers[i] = Conversation.GetMemory<string>($"{MemoryAnswerKey}{i}");
            }

            await Conversation.Storage.StoreResponse(Conversation.ActiveEvent.Code, new StoreModels.QuestionnaireResponse {
                Responses = answers,
                UserId = Conversation.CurrentUser.UserId,
                UserFirstSeen = Conversation.CurrentUser.FirstSeenOn,
                UserName = Conversation.CurrentUser.Name,
                Timestamp = DateTime.UtcNow
            });

            await Conversation.ClearMemory(MemoryStateKey);
        }

        public override async Task<bool> Process(Update update) {
            var index = (int)Conversation.GetMemory(MemoryStateKey, 0L);
            try {
                if (await ProcessAnswer(update, index)) {
                    Logger.LogDebug("Answer processed, advancing");
                    index++;
                }
            }
            catch (Exception ex) {
                Logger.LogError(ex, "Failed to process questionnaire answer, skipping");
                await Conversation.SetState((int)BotState.CertificateGeneration);
            }

            if (index <= -1 || index >= Conversation.ActiveEvent.Questionnaire.Questions.Length) {
                Logger.LogInformation("Moved to question index {0}, exiting questionnaire", index);
                await Conversation.SetState((int)BotState.CertificateGeneration);
            }
            else {
                await Conversation.SetMemory(MemoryStateKey, index);
                await DeliverQuestion(index);
            }

            return true;
        }

        private async Task<bool> ProcessAnswer(Update update, int index) {
            var question = Conversation.ActiveEvent.Questionnaire.Questions[index];
            switch (question.Kind) {
                case "string": {
                        if (update.Message == null || string.IsNullOrWhiteSpace(update.Message.Text)) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorString,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }

                        await Conversation.SetMemory($"{MemoryAnswerKey}{index}", update.Message.Text);
                        return true;
                    }

                case "age": {
                        if (update.Message == null || string.IsNullOrWhiteSpace(update.Message.Text)) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAgeInvalid,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        if (!int.TryParse(update.Message.Text, out var age)) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAgeInvalid,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        if (age < 5) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAgeTooLow,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        if (age > 99) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAgeTooHigh,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }

                        await Conversation.SetMemory($"{MemoryAnswerKey}{index}", age.ToString());
                        return true;
                    }

                case "alternative": {
                        if (update.CallbackQuery == null || update.CallbackQuery.Data == null) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAlternative,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        if (!int.TryParse(update.CallbackQuery.Data, out var selectionIndex)) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAlternative,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }
                        if (selectionIndex <= 0 || selectionIndex > question.Answers.Length) {
                            await Bot.SendMessage(Conversation.TelegramId,
                                Strings.QuestionnaireErrorAlternative,
                                parseMode: ParseMode.Html
                            );
                            return false;
                        }

                        await Conversation.SetMemory($"{MemoryAnswerKey}{index}", selectionIndex.ToString());
                        return true;
                    }
            }

            return false;
        }

        private async Task DeliverQuestion(int index) {
            var question = Conversation.ActiveEvent.Questionnaire.Questions[index];
            switch (question.Kind) {
                case "alternative": {
                        await Bot.SendMessage(Conversation.TelegramId,
                            question.Text.Localize(),
                            parseMode: ParseMode.Html,
                            replyMarkup: new InlineKeyboardMarkup(
                                question.Answers.Select((a, index) => {
                                    return new InlineKeyboardButton[]
                                    {
                                        new InlineKeyboardButton(a.Localize()) {
                                            CallbackData = (index + 1).ToString()
                                        }
                                    };
                                })
                            )
                        );
                    }
                    break;

                case "age":
                case "string":
                default:
                    await Bot.SendMessage(Conversation.TelegramId,
                        question.Text.Localize(),
                        parseMode: ParseMode.Html
                    );
                    break;
            }
        }

    }
}
