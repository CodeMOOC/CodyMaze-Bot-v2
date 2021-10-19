using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CodyMazeBot.Game {
    [StateHandler(BotState.WaitingForLocation)]
    public class WaitForLocationProcessor : BaseStateProcessor {

        public WaitForLocationProcessor(
            Conversation conversation,
            ITelegramBotClient bot,
            ILogger<WaitForLocationProcessor> logger
        ) : base(conversation, bot, logger) {

        }

        public override async Task<bool> Process(Update update) {
            if(!Conversation.IncomingCoordinate.HasValue) {
                // This happens if the user does not scan a QR Code
                return false;
            }

            if (Conversation.CurrentUser.MoveCount == 0) {
                // Welcome message (TODO)

                // Block if not on border
                if (!Conversation.IncomingCoordinate.Value.IsOnGridBorder()) {
                    await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        Strings.WaitForLocationFirstCoordinateWrong,
                        ParseMode.Html);
                    return true;
                }

                // Tell user to look in right direction, if not already
                var requiredDirection = Conversation.IncomingCoordinate.Value.GetInitialDirection();
                if (Conversation.IncomingCoordinate.Value.Direction != requiredDirection) {
                    await Bot.SendTextMessageAsync(Conversation.TelegramId,
                        string.Format(Strings.WaitForLocationFirstSendDirection, GetFacingString(requiredDirection)),
                        parseMode: ParseMode.Html
                    );
                }
            }

            if (Conversation.IncomingCoordinate.Value.Direction.HasValue) {
                // Arrived on new coordinate in one shot
                await HandleArrivalOn(update, Conversation.IncomingCoordinate.Value);

                return true;
            }
            else {
                // Must ask for direction
                await Conversation.AcceptPartialCoordinate(Conversation.IncomingCoordinate.Value);

                await Bot.SendTextMessageAsync(Conversation.TelegramId,
                    string.Format(Strings.AcceptCoordinateWaitForDirection),
                    parseMode: ParseMode.Html,
                    replyMarkup: new InlineKeyboardMarkup(
                        new InlineKeyboardButton[][] {
                                new InlineKeyboardButton[] {
                                    new InlineKeyboardButton { Text = Strings.DirectionNorth, CallbackData = "N" },
                                },
                                new InlineKeyboardButton[] {
                                    new InlineKeyboardButton { Text = Strings.DirectionWest, CallbackData = "W" },
                                    new InlineKeyboardButton { Text = Strings.DirectionEast, CallbackData = "E" },
                                },
                                new InlineKeyboardButton[] {
                                    new InlineKeyboardButton { Text = Strings.DirectionSouth, CallbackData = "S" },
                                }
                        }
                    )
                );

                return true;
            }
        }

    }
}
