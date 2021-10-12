using CodyMazeBot.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CodyMazeBot.Controllers {
    [Route("")]
    public class WebhookController : ControllerBase {

        Conversation _conversation;
        IServiceProvider _serviceProvider;
        ILogger<WebhookController> _logger;

        public WebhookController(
            Conversation conversation,
            IServiceProvider serviceProvider,
            ILogger<WebhookController> logger
        ) {
            _conversation = conversation;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Process(
            [FromBody] Update update
        ) {
            _logger.LogDebug("Processing update {0} from {1}", update?.Id, update?.Message?.From?.Username);
            await _conversation.LoadUser(update);

            var handlerTask = update.Type switch {
                UpdateType.Message => HandleIncomingMessage(update),
                _ => HandleUnknownUpdate(update)
            };
            try {
                await handlerTask;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed handling update ({0})", ex.Message);
            }

            return Ok();
        }

        private async Task HandleIncomingMessage(Update update) {
            _logger.LogDebug("Received message: {0}", update.Message.Text);

            ICommand command = update.Message.Text.Split(' ').First() switch {
                "/language" => _serviceProvider.GetService<LanguageCommand>(),
                "/help" => _serviceProvider.GetService<HelpCommand>(),
                _ => null
            };
            if(command != null) {
                _logger.LogDebug("Processing command with processor {0}", command.GetType());
                await command.ProcessCommand(update);
                return;
            }

            // Process other messages
        }

        private Task HandleUnknownUpdate(Update update) {
            _logger.LogDebug("Ignoring unsupported update type ({0})", update.Type);
            return Task.CompletedTask;
        }

    }
}
