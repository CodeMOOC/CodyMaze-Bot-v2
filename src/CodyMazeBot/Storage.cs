using CodyMazeBot.StoreModels;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    
    public class Storage {

        private readonly ILogger<Storage> _logger;

        public Storage(
            ILogger<Storage> logger
        ) {
            _logger = logger;
        }

        private FirestoreDb _firestore;

        private async Task<FirestoreDb> GetFirestore() {
            if (_firestore == null) {
                _firestore = await FirestoreDb.CreateAsync(Environment.GetEnvironmentVariable("GOOGLE_PROJECT_ID"));
            }
            return _firestore;
        }

        private async Task<T> FetchDocument<T>(string path) {
            var doc = _firestore.Document(path);
            var snapshot = await doc.GetSnapshotAsync();
            if (snapshot == null || !snapshot.Exists) {
                return default;
            }

            return snapshot.ConvertTo<T>();
        }

        private string GetEventPath(string eventCode) {
            return string.Format("events/{0}", eventCode);
        }

        public Task<Event> FetchEvent(string eventCode) {
            return FetchDocument<Event>(GetEventPath(eventCode));
        }

        public Task<Category> FetchCategory(string eventCode, string categoryCode) {
            return FetchDocument<Category>(string.Format("events/{0}/categories/{1}", eventCode, categoryCode));
        }

        public Task<Question> FetchQuestion(string eventCode, string categoryCode, string questionId) {
            return FetchDocument<Question>(string.Format("events/{0}/categories/{1}/questions/{2}", eventCode, categoryCode, questionId));
        }

        private string GetUserPath(long telegramId) {
            return string.Format("users/{0}", telegramId);
        }

        private string GetUserPath(string userId) {
            return string.Format("users/{0}", userId);
        }

        private Task<User> FetchExistingUser(int telegramId) {
            return FetchDocument<User>(GetUserPath(telegramId));
        }

        /// <summary>
        /// Retrives a user or creates one, if needed.
        /// </summary>
        /// <param name="telegramId">Unique Telegram identifier.</param>
        public async Task<User> RetrieveUser(long telegramId) {
            var doc = (await GetFirestore()).Document(GetUserPath(telegramId));
            
            var snapshot = await doc.GetSnapshotAsync();
            if(snapshot != null && snapshot.Exists) {
                return snapshot.ConvertTo<User>();
            }

            _ = await doc.CreateAsync(new User {
                UserId = telegramId.ToString(),
                State = 0,
                FirstSeenOn = DateTime.UtcNow,
                LastUpdateOn = DateTime.UtcNow
            });
            snapshot = await doc.GetSnapshotAsync();
            if(snapshot == null || !snapshot.Exists) {
                throw new Exception("Snapshot of newly created user cannot be retrieved");
            }
            return snapshot.ConvertTo<User>();
        }

        public async Task UpdateUserLanguage(string userId, string languageCode) {
            var doc = (await GetFirestore()).Document(GetUserPath(userId));
            await doc.SetAsync(new User {
                LanguageCodeOverride = languageCode,
                LastUpdateOn = DateTime.UtcNow
            }, SetOptions.MergeFields(User.LanguageCodeOverrideProp, User.LastUpdateOnProp));
        }

        public async Task UpdateUserState(string userId, int state) {
            var doc = (await GetFirestore()).Document(GetUserPath(userId));
            await doc.SetAsync(new User {
                State = state,
                LastUpdateOn = DateTime.UtcNow
            }, SetOptions.MergeFields(User.StateProp, User.LastUpdateOnProp));
        }

    }

}
