using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CodyMazeBot.Controllers {
    [Route("")]
    public class WebhookController : ControllerBase {

        Conversation _conversation;
        ILogger<WebhookController> _logger;

        public WebhookController(
            Conversation conversation,
            ILogger<WebhookController> logger
        ) {
            _conversation = conversation;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Process(
            [FromBody] Update update
        ) {
            _logger.LogDebug("Processing update {0} from {1}", update?.Id, update?.Message?.From?.Username);
            await _conversation.LoadUser(update.Message.From.Id);

            return Ok();
        }

    }
}
