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
        public long TelegramId { get; private set; }

        public int State {
            get {
                if (User == null)
                    return 0;
                else
                    return User.State;
            }
        }

        public GridCoordinate? IncomingCoordinate { get; set; }

        public Conversation(
            Storage storage,
            ILogger<Conversation> logger
        ) {
            _storage = storage;
            _logger = logger;
        }

        public async Task LoadUser(Update update) {
            TelegramId = update.GetChatId().GetValueOrDefault(0);
            if(TelegramId == 0) {
                return;
            }

            User = await _storage.RetrieveUser(TelegramId);
            _logger.LogDebug("Loaded user profile for ID {0}", TelegramId);

            var selectedLanguage = User.LanguageCodeOverride ?? update.Message.From.LanguageCode ?? "en-US";
            CurrentLanguage = CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo(selectedLanguage);
            _logger.LogDebug("Selected culture {0} for language code {1}", CurrentLanguage, selectedLanguage);
        }

        public async Task<bool> SetLanguage(string languageCode) {
            if(User == null) {
                return false;
            }

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

        public async Task<bool> SetState(int state, bool storePrevious = false) {
            if (User == null) {
                return false;
            }

            try {
                User.PreviousState = (storePrevious) ? User.State : null;
                User.State = state;
                await _storage.UpdateUserState(User.UserId, state, User.PreviousState);
                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to set state");
                return false;
            }
        }

        public async Task<bool> RestoreState(int defaultState) {
            if(User == null) {
                return false;
            }

            try {
                User.State = User.PreviousState.GetValueOrDefault(defaultState);
                User.PreviousState = null;
                await _storage.UpdateUserState(User.UserId, User.State, User.PreviousState);
                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to restore state");
                return false;
            }
        }

    }

}
