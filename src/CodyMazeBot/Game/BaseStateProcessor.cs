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

        private IEnumerable<IEnumerable<InlineKeyboardButton>> GetAnswerKeyboard(Question question) {
            var rnd = new Random();
            return question.Answers.Select((answer, index) => (answer, index))
                .OrderBy(_ => rnd.NextDouble())
                .Select(elem => new InlineKeyboardButton[] {
                    new InlineKeyboardButton {
                        Text = elem.answer.Localize(),
                        CallbackData = elem.index == 0 ? "CORRECT" : "WRONG"
                    }
                });
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

                    var lastCoordinate = Conversation.CurrentUser.LastMoveCoordinate;
                    if(!lastCoordinate.HasValue) {
                        Logger.LogError("Wrong move, must backtrack, but no coordinate found");
                        return;
                    }

                    await Conversation.SetState((int)BotState.WaitingForLocation);

                    await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        string.Format(
                            Strings.WrongMove,
                            lastCoordinate.Value.CoordinateString,
                            GetFacingString(lastCoordinate.Value.Direction)
                        ),
                        parseMode: ParseMode.Html);

                    return;
                }
            }

            Logger.LogInformation("Move to {0} valid", coordinate);
            await Conversation.RegisterMove(coordinate);

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                Strings.CorrectPosition,
                parseMode: ParseMode.Html
            );

            if(Conversation.ActiveEvent == null) {
                // TODO
                return;
            }

            if(!Conversation.ActiveEvent.Grid.ContainsKey(coordinate.CoordinateString.ToLowerInvariant())) {
                Logger.LogError("Event grid does not contain info for coordinate {0}", coordinate.CoordinateString);

                // TODO
                return;
            }

            var gridCell = Conversation.ActiveEvent.Grid[coordinate.CoordinateString.ToLowerInvariant()];

            (var category, var question) = await Conversation.AssignNewQuestion(gridCell.CategoryCode);
            if(category == null || question == null) {
                // Move ahead without question
                await AssignNextDestination(update);
                return;
            }

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                string.Format(Strings.AssignQuiz,
                    category.Title.Localize(),
                    question.QuestionText.Localize()),
                parseMode: ParseMode.Html,
                replyMarkup: new InlineKeyboardMarkup(GetAnswerKeyboard(question))
            );
        }

        protected async Task AssignNextDestination(Update update) {
            if(Conversation.CurrentUser.MoveCount > MazeGenerator.LastMove) {
                Logger.LogInformation("Maze completed with {0} moves", Conversation.CurrentUser.MoveCount);

                await Bot.SendTextMessageAsync(Conversation.TelegramId,
                    Strings.Victory,
                    parseMode: ParseMode.Html
                );
            }

            (var target, var code) = MazeGenerator.GenerateInstructions(
                Conversation.CurrentUser.LastMoveCoordinate.Value,
                Conversation.CurrentUser.MoveCount,
                Conversation.ActiveEvent.Grid
            );

            await Conversation.AssignNewDestination(target.ToString());

            await Bot.SendTextMessageAsync(Conversation.TelegramId,
                string.Format(Strings.AssignCode, code),
                parseMode: ParseMode.Html
            );
        }

        protected Task ReplyCannotHandle(Update update, string prompt = null) {
            string output = Strings.CannotHandle;
            if(!string.IsNullOrWhiteSpace(prompt)) {
                output += " " + prompt;
            }

            return Bot.SendTextMessageAsync(Conversation.TelegramId, output, ParseMode.Html);
        }

    }
}
