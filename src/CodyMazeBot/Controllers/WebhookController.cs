using CodyMazeBot.Commands;
using CodyMazeBot.Game;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Controllers {
    [Route("")]
    public class WebhookController : ControllerBase {

        private readonly Conversation _conversation;
        private readonly ITelegramBotClient _bot;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WebhookController> _logger;

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
            if (update.Message == null && update.CallbackQuery == null) {
                // Ignore update
                return Ok();
            }

            _logger.LogDebug("Processing update {0} {1}, payload: \"{2}\"",
                update?.Id,
                (update.Message != null) ? "message" : "callback",
                update.Message?.Text ?? update.CallbackQuery?.Data);

            if (update.CallbackQuery != null) {
                // Approve callback right away
                await _bot.AnswerCallbackQuery(update.CallbackQuery.Id);
            }

            if (!await _conversation.LoadUser(update)) {
                return Ok();
            }
            _conversation.PerformLanguageSet();

            (var commandHandled, var shortCircuit) = await HandleCommand(update);
            _logger.LogDebug("Command handled {0} short-circuit {1}", commandHandled, shortCircuit);
            if (shortCircuit) {
                return Ok();
            }

            var stateHandled = await HandleState(update);
            _logger.LogDebug("State handled: {0}", stateHandled);

            // Message received and not handled neither as command nor in state processor
            if (update.Message != null && !(commandHandled || stateHandled)) {
                // Huh?
                await _bot.SendMessage(_conversation.TelegramId, Strings.CannotHandle, parseMode: ParseMode.Html);
            }

            return Ok();
        }

        private async Task<(bool Handled, bool ShortCircuit)> HandleCommand(Update update) {
            if (update.Message == null || string.IsNullOrEmpty(update.Message.Text)) {
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

            BotState inState;
            bool stateProcessed;
            BaseStateProcessor previousProcessor = null;
            do {
                if (!Enum.IsDefined(typeof(BotState), _conversation.State)) {
                    return false;
                }
                inState = (BotState)_conversation.State;
                _logger.LogDebug("Incoming state to handle: {0}", inState);

                if (!processorTypes.ContainsKey(inState)) {
                    _logger.LogDebug("No processor that handles state {0}", inState);
                    return false;
                }

                if (previousProcessor != null) {
                    _logger.LogDebug("Handling exit from previous processor {0}", previousProcessor.GetType());
                    await previousProcessor.HandleStateExit(update);
                }

                var processorType = processorTypes[inState];
                var processor = (BaseStateProcessor)_serviceProvider.GetService(processorType);

                if (previousProcessor != null) {
                    _logger.LogDebug("Handling entry in next processor {0}", processorType);
                    await processor.HandleStateEntry(update);
                    stateProcessed = true; // if entering a new processor, we consider the state as handled
                }
                else {
                    _logger.LogDebug("Processing state with processor {0}", processorType);
                    stateProcessed = await processor.Process(update);
                }

                previousProcessor = processor;
            }
            while (stateProcessed && (int)inState != _conversation.State);

            return stateProcessed;
        }

    }
}
