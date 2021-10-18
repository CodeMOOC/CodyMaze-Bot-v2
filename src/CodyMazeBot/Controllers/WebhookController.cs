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
            _logger.LogDebug("Processing update {0} from {1} \"{2}\"",
                update?.Id, update.Message?.From?.Username, update.Message?.Text);

            await _conversation.LoadUser(update);

            (var commandHandled, var shortCircuit) = await HandleCommand(update);

            // Perform state processing, if not short-circuited
            if(!shortCircuit && Enum.IsDefined(typeof(BotState), _conversation.State)) {
                var processorTypes = Startup.StateProcessors;
                if(processorTypes.ContainsKey((BotState)_conversation.State)) {
                    var processorType = processorTypes[(BotState)_conversation.State];
                    var processor = (BaseStateProcessor)_serviceProvider.GetService(processorType);
                    
                    if(await processor.Process(update)) {
                        return Ok();
                    }
                }
            }

            if(!commandHandled) {
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

    }
}
