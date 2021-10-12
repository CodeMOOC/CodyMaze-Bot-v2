using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    
    public class Conversation {

        private readonly Storage _storage;
        private readonly ILogger<Conversation> _logger;

        public User User { get; private set; }

        public Conversation(
            Storage storage,
            ILogger<Conversation> logger
        ) {
            _storage = storage;
            _logger = logger;
        }

        public async Task LoadUser(long telegramId) {
            User = await _storage.RetrieveUser(telegramId);
            _logger.LogDebug("Loaded user profile for ID {0}", telegramId);
        }

    }

}
