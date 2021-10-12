using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CodyMazeBot {
    
    public class Conversation {

        private readonly Storage _storage;
        private readonly ILogger<Conversation> _logger;

        public StoreModels.User User { get; private set; }
        public CultureInfo CurrentLanguage { get; private set; }

        public Conversation(
            Storage storage,
            ILogger<Conversation> logger
        ) {
            _storage = storage;
            _logger = logger;
        }

        public async Task LoadUser(Update update) {
            var telegramId = update.Message?.From?.Id;
            if(!telegramId.HasValue) {
                return;
            }

            User = await _storage.RetrieveUser(telegramId.Value);
            _logger.LogDebug("Loaded user profile for ID {0}", telegramId);

            var selectedLanguage = User.LanguageCodeOverride ?? update.Message.From.LanguageCode ?? "en-US";
            CurrentLanguage = CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo(selectedLanguage);
            _logger.LogDebug("Selected culture {0} for language code {1}", CurrentLanguage, selectedLanguage);
        }

        public async Task<bool> SetLanguage(string languageCode) {
            try {
                CurrentLanguage = CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo(languageCode);

                await _storage.UpdateUserLanguage(User.UserId, CurrentLanguage.TwoLetterISOLanguageName);

                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to set language");
                return false;
            }
        }

    }

}
