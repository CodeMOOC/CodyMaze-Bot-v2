using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CodyMazeBot.Game {
    public abstract class BaseStateProcessor {

        protected Conversation Conversation { get; init; }
        protected ITelegramBotClient Bot { get; init; }
        protected ILogger<BaseStateProcessor> Logger { get; init; }

        public BaseStateProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<BaseStateProcessor> logger
        ) {
            Conversation = conversation;
            Bot = bot;
            Logger = logger;
        }

        protected string GetFacingString(Direction? dir) {
            return dir switch {
                Direction.North => Strings.FacingNorth,
                Direction.East => Strings.FacingEast,
                Direction.South => Strings.FacingSouth,
                Direction.West => Strings.FacingWest,
                _ => string.Empty
            };
        }

        public abstract Task<bool> Process(Update update);

        public virtual Task HandleStateEntry(Update update) {
            return Task.CompletedTask;
        }

        public virtual Task HandleStateExit(Update update) {
            return Task.CompletedTask;
        }

        protected async Task HandleGameCompletion(Update update) {
            Logger.LogInformation("Maze completed with {0} moves", Conversation.CurrentUser.MoveCount);

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                Strings.Victory,
                parseMode: ParseMode.Html
            );

            await Conversation.SetState((int)BotState.Questionnaire);
        }

        private (string AnswerText, bool IsCorrect)[] PrepareAnswers(Question question) {
            var rnd = new Random();
            return question.Answers.Select((answer, index) => (answer, index))
                .OrderBy(_ => rnd.NextDouble())
                .Select(elem => (elem.answer.Localize(), elem.index == 0))
                .ToArray();
        }

        protected async Task HandleArrivalOn(Update update, GridCoordinate coordinate) {
            Logger.LogInformation("Handling arrival on {0}", coordinate);

            if (Conversation.CurrentUser.MoveCount == 0) {
                // This is a start move, validate
                if (!coordinate.IsOnGridBorder()) {
                    await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        Strings.WaitForLocationFirstCoordinateWrong,
                        ParseMode.Html);
                    return;
                }

                var requiredDirection = coordinate.GetInitialDirection();
                if (coordinate.Direction != requiredDirection) {
                    await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        string.Format(Strings.WaitForLocationWrongDirection, GetFacingString(requiredDirection)),
                        parseMode: ParseMode.Html
                    );
                    return;
                }
            }
            else {
                // This is an in-game move, validate
                if(!coordinate.Equals(Conversation.CurrentUser.NextTargetCoordinate)) {
                    Logger.LogInformation("Move invalid, expected {0} but reached {1}",
                        Conversation.CurrentUser.NextTargetCoordinate, coordinate);

                    await Conversation.SetState((int)BotState.WaitingForLocation);

                    var lastCoordinate = Conversation.CurrentUser.LastMoveCoordinate;
                    if(!lastCoordinate.HasValue) {
                        Logger.LogError("Wrong move, must backtrack, but no coordinate found");
                        return;
                    }

                    if(Conversation.CurrentUser.NextTargetCode == null) {
                        await Bot.SendTextMessageAsync(Conversation.TelegramId,
                            string.Format(
                                Strings.WrongMoveWithoutCode,
                                lastCoordinate.Value.CoordinateString,
                                GetFacingString(lastCoordinate.Value.Direction)
                            ),
                            parseMode: ParseMode.Html);
                    }
                    else {
                        await Bot.SendTextMessageAsync(Conversation.TelegramId,
                            string.Format(
                                Strings.WrongMove,
                                lastCoordinate.Value.CoordinateString,
                                GetFacingString(lastCoordinate.Value.Direction),
                                Conversation.CurrentUser.NextTargetCode
                            ),
                            parseMode: ParseMode.Html);
                    }

                    return;
                }
            }

            Logger.LogInformation("Move to {0} valid", coordinate);
            await Conversation.RegisterMove(coordinate);

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                string.Format(Strings.CorrectPosition, coordinate.CoordinateString, GetFacingString(coordinate.Direction)),
                parseMode: ParseMode.Html
            );

            var gridCell = Conversation.GetGridCell(coordinate);
            (var category, var question) = await Conversation.AssignNewQuestion(gridCell.CategoryCode);
            if(category == null || question == null) {
                Logger.LogInformation("Current grid has no category for coordinate {0}, skipping to next destination", coordinate);
                await AssignNextDestination(update);
                return;
            }

            var shuffledAnswers = PrepareAnswers(question);

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                string.Format(Strings.AssignQuiz,
                    category.Title.Localize(),
                    question.QuestionText.Localize(),
                    shuffledAnswers[0].AnswerText,
                    shuffledAnswers[1].AnswerText,
                    shuffledAnswers[2].AnswerText
                ),
                parseMode: ParseMode.Html,
                replyMarkup: new InlineKeyboardMarkup(new InlineKeyboardButton[] {
                    new InlineKeyboardButton(Strings.AnswerCode1) {
                        CallbackData = shuffledAnswers[0].IsCorrect ? "CORRECT" : "WRONG"
                    },
                    new InlineKeyboardButton(Strings.AnswerCode2) {
                        CallbackData = shuffledAnswers[1].IsCorrect ? "CORRECT" : "WRONG"
                    },
                    new InlineKeyboardButton(Strings.AnswerCode3) {
                        CallbackData = shuffledAnswers[2].IsCorrect ? "CORRECT" : "WRONG"
                    },
                })
            );
        }

        protected async Task AssignNextDestination(Update update) {
            if(Conversation.CurrentUser.MoveCount > MazeGenerator.LastMove) {
                await HandleGameCompletion(update);
                return;
            }

            try {
                (var target, var code) = MazeGenerator.GenerateInstructions(
                    Conversation.CurrentUser.LastMoveCoordinate.Value,
                    Conversation.CurrentUser.MoveCount,
                    Conversation.ActiveGrid
                );

                await Conversation.AssignNewDestination(target.ToString(), code);

                await Bot.SendTextMessageAsync(Conversation.TelegramId,
                    string.Format(Strings.AssignCode, code),
                    parseMode: ParseMode.Html
                );
            }
            catch(Exception ex) {
                Logger.LogError(ex, "Failed to generate and assign instructions");
                await CriticalError();
                return;
            }
        }

        protected Task ReplyCannotHandle(Update update, string prompt = null) {
            string output = Strings.CannotHandle;
            if(!string.IsNullOrWhiteSpace(prompt)) {
                output += " " + prompt;
            }

            return Bot.SendTextMessageAsync(Conversation.TelegramId, output, ParseMode.Html);
        }

        protected Task CriticalError() {
            return Bot.SendTextMessageAsync(Conversation.TelegramId, Strings.CriticalError, ParseMode.Html);
        }

    }
}
