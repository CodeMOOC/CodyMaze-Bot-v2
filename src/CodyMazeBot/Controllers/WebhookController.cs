using CodyMazeBot.Commands;
using CodyMazeBot.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Controllers {
    [Route("")]
    public class WebhookController : ControllerBase {

        Conversation _conversation;
        ITelegramBotClient _bot;
        IServiceProvider _serviceProvider;
        ILogger<WebhookController> _logger;

        public WebhookController(
            Conversation conversation,
            ITelegramBotClient bot,
            IServiceProvider serviceProvider,
            ILogger<WebhookController> logger
        ) {
            _conversation = conversation;
            _bot = bot;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Process(
            [FromBody] Update update
        ) {
            if(update.Message == null && update.CallbackQuery == null) {
                // Ignore update
                return Ok();
            }

            _logger.LogDebug("Processing update {0} {1}, payload: \"{2}\"",
                update?.Id,
                (update.Message != null) ? "message" : "callback",
                update.Message?.Text ?? update.CallbackQuery?.Data);

            if(!await _conversation.LoadUser(update)) {
                return Ok();
            }

            (var commandHandled, var shortCircuit) = await HandleCommand(update);
            _logger.LogDebug("Command handled {0} short-circuit {1}", commandHandled, shortCircuit);
            if(shortCircuit) {
                return Ok();
            }

            var stateHandled = await HandleState(update);
            _logger.LogDebug("State handled {0}", stateHandled);

            if(!commandHandled && !stateHandled) {
                // Huh?
                await _bot.SendTextMessageAsync(_conversation.TelegramId, Strings.CannotHandle, ParseMode.Html);
            }

            return Ok();
        }

        private async Task<(bool Handled, bool ShortCircuit)> HandleCommand(Update update) {
            if(update.Message == null || string.IsNullOrEmpty(update.Message.Text)) {
                return (false, false);
            }

            ICommand command = update.Message.Text.Split(' ').First() switch {
                "/start" => _serviceProvider.GetService<StartCommand>(),
                "/language" => _serviceProvider.GetService<LanguageCommand>(),
                "/help" => _serviceProvider.GetService<HelpCommand>(),
                "/reset" => _serviceProvider.GetService<ResetCommand>(),
                _ => null
            };
            if (command != null) {
                _logger.LogDebug("Processing command with processor {0}", command.GetType());
                (var newState, var shortCircuit) = await command.ProcessCommand(update);
                _logger.LogDebug("Command returned new state {0} and short circuit {1}", newState, shortCircuit);

                if (newState.HasValue) {
                    await _conversation.SetState((int)newState.Value, true);
                }

                return (true, shortCircuit);
            }

            return (false, false);
        }

        private async Task<bool> HandleState(Update update) {
            var processorTypes = Startup.StateProcessors;

            if (!Enum.IsDefined(typeof(BotState), _conversation.State)) {
                return false;
            }
            BotState currState = (BotState)_conversation.State;

            if (!processorTypes.ContainsKey(currState)) {
                _logger.LogDebug("No processor that handles state {0}", currState);
                return false;
            }
            var processorType = processorTypes[(BotState)_conversation.State];
            var processor = (BaseStateProcessor)_serviceProvider.GetService(processorType);
            _logger.LogDebug("Processing state with processor {0}", processorType);
            bool processed = await processor.Process(update);

            if(processed && (int)currState != _conversation.State) {
                // State was processed and has changed
                processorType = processorTypes[(BotState)_conversation.State];
                processor = (BaseStateProcessor)_serviceProvider.GetService(processorType);
                _logger.LogDebug("Processing state change with processor {0}", processorType);
                await processor.HandleStateEntry(update);
            }

            return processed;
        }

    }
}
