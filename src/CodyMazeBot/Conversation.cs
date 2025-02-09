using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CodyMazeBot.StoreModels;
using Microsoft.Extensions.Logging;

namespace CodyMazeBot {

    public class Conversation {

        private readonly Storage _storage;
        private readonly ILogger<Conversation> _logger;

        public Storage Storage
        {
            get {
                return _storage;
            }
        }

        public User CurrentUser { get; private set; }
        public CultureInfo CurrentLanguage { get; private set; }
        public long TelegramId { get; private set; }
        public Event ActiveEvent { get; private set; }

        public int State {
            get {
                if (CurrentUser == null)
                    return 0;
                else
                    return CurrentUser.State;
            }
        }

        public GridCoordinate? IncomingCoordinate { get; set; }

        private static readonly Dictionary<string, GridCell> DefaultGrid = new Dictionary<string, GridCell> {
            { "a1", new GridCell { HasStar = true  } },
            { "a2", new GridCell { HasStar = false } },
            { "a3", new GridCell { HasStar = false } },
            { "a4", new GridCell { HasStar = true  } },
            { "a5", new GridCell { HasStar = false } },
            { "b1", new GridCell { HasStar = true  } },
            { "b2", new GridCell { HasStar = false } },
            { "b3", new GridCell { HasStar = false } },
            { "b4", new GridCell { HasStar = false } },
            { "b5", new GridCell { HasStar = false } },
            { "c1", new GridCell { HasStar = false } },
            { "c2", new GridCell { HasStar = false } },
            { "c3", new GridCell { HasStar = false } },
            { "c4", new GridCell { HasStar = false } },
            { "c5", new GridCell { HasStar = true  } },
            { "d1", new GridCell { HasStar = false } },
            { "d2", new GridCell { HasStar = false } },
            { "d3", new GridCell { HasStar = false } },
            { "d4", new GridCell { HasStar = false } },
            { "d5", new GridCell { HasStar = false } },
            { "e1", new GridCell { HasStar = false } },
            { "e2", new GridCell { HasStar = true  } },
            { "e3", new GridCell { HasStar = false } },
            { "e4", new GridCell { HasStar = false } },
            { "e5", new GridCell { HasStar = false } },
        };

        public IDictionary<string, GridCell> ActiveGrid {
            get {
                if(ActiveEvent?.Grid != null) {
                    return ActiveEvent.Grid;
                }
                else {
                    return DefaultGrid;
                }
            }
        }

        public GridCell GetGridCell(GridCoordinate coordinate) {
            string coordinateKey = coordinate.CoordinateString.ToLowerInvariant();
            if (!ActiveGrid.ContainsKey(coordinateKey)) {
                return new GridCell { };
            }
            else {
                return ActiveGrid[coordinateKey];
            }
        }

        public Conversation(
            Storage storage,
            ILogger<Conversation> logger
        ) {
            _storage = storage;
            _logger = logger;
        }

        /// <summary>
        /// Aux method that performs language set from main task.
        /// Call from main thread.
        /// </summary>
        public void PerformLanguageSet() {
            CultureInfo.CurrentCulture = CurrentLanguage;
            CultureInfo.CurrentUICulture = CurrentLanguage;
            _logger.LogDebug("Switched to language {0} ({1})", CurrentLanguage.DisplayName, CurrentLanguage.Name);
        }

        public async Task<bool> LoadUser(Telegram.Bot.Types.Update update) {
            TelegramId = update.GetChatId().GetValueOrDefault(0);
            if(TelegramId == 0) {
                _logger.LogWarning("Unable to load incoming message Telegram user ({0})", Newtonsoft.Json.JsonConvert.SerializeObject(update));
                return false;
            }

            var user = update.GetFrom();
            string username = string.Join(' ', user.FirstName, user.LastName);

            CurrentUser = await _storage.RetrieveUser(TelegramId, username);
            _logger.LogDebug("Loaded user profile for ID {0}", TelegramId);

            CurrentLanguage = new CultureInfo(CurrentUser.LanguageCodeOverride ?? update.GetFrom()?.LanguageCode ?? "it-IT");
            _logger.LogDebug("Selected culture {0} {1} (user override {2}, Telegram language {3})",
                CurrentLanguage.DisplayName,
                CurrentLanguage.Name,
                CurrentUser.LanguageCodeOverride,
                update.GetFrom()?.LanguageCode
            );

            if(!string.IsNullOrEmpty(CurrentUser.CurrentEvent)) {
                ActiveEvent = await _storage.FetchEvent(CurrentUser.CurrentEvent);
            }

            return true;
        }

        public async Task<bool> SetLanguage(string languageCode) {
            if(CurrentUser == null) {
                return false;
            }

            try {
                CurrentLanguage = new CultureInfo(languageCode);

                CurrentUser.LanguageCodeOverride = CurrentLanguage.TwoLetterISOLanguageName;
                await _storage.UpdateUser(CurrentUser, User.LanguageCodeOverrideProp);
                
                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to set language");
                return false;
            }
        }

        public async Task<bool> SetState(int state, bool storePrevious = false) {
            if (CurrentUser == null) {
                return false;
            }

            try {
                CurrentUser.PreviousState = (storePrevious) ? CurrentUser.State : null;
                CurrentUser.State = state;
                await _storage.UpdateUser(CurrentUser, User.StateProp, User.PreviousStateProp);
                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to set state");
                return false;
            }
        }

        public async Task<bool> RestoreState(int defaultState) {
            if(CurrentUser == null) {
                return false;
            }

            try {
                CurrentUser.State = CurrentUser.PreviousState.GetValueOrDefault(defaultState);
                CurrentUser.PreviousState = null;
                await _storage.UpdateUser(CurrentUser, User.StateProp, User.PreviousStateProp);
                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to restore state");
                return false;
            }
        }

        public async Task<bool> AcceptPartialCoordinate(GridCoordinate coord) {
            if (CurrentUser == null) {
                return false;
            }

            try {
                CurrentUser.State = (int)BotState.WaitingForDirection;
                CurrentUser.PreviousState = null;
                CurrentUser.PartialCoordinate = coord.ToString();
                await _storage.UpdateUser(CurrentUser,
                    User.StateProp, User.PreviousStateProp, User.PartialCoordinateProp);
                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to accept partial coordinate");
                return false;
            }
        }

        public async Task<bool> ResetGame() {
            if (CurrentUser == null) {
                return false;
            }

            try {
                CurrentUser.State = (int)BotState.WaitingForLocation;
                CurrentUser.PreviousState = null;
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                CurrentUser.CurrentEvent = null;
                CurrentUser.NextTargetCoordinate = null;
                CurrentUser.PartialCoordinate = null;
                CurrentUser.Moves = null;
                CurrentUser.Memory = null;
                await _storage.UpdateUser(CurrentUser,
                    User.StateProp,
                    User.PreviousStateProp,
                    User.LastUpdateOnProp,
                    User.CurrentEventProp,
                    User.NextTargetCoordinateProp,
                    User.PartialCoordinateProp,
                    User.MovesProp,
                    User.MemoryProp
                );
                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to reset game");
                return false;
            }
        }

        public async Task<bool> SetEventCode(string eventCode) {
            eventCode = eventCode.ToLowerInvariant();
            if (CurrentUser == null) {
                return false;
            }
            if(eventCode.Equals(CurrentUser.CurrentEvent)) {
                return true;
            }

            try {
                CurrentUser.CurrentEvent = eventCode;
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                await _storage.UpdateUser(CurrentUser,
                    User.CurrentEventProp,
                    User.LastUpdateOnProp
                );

                ActiveEvent = await _storage.FetchEvent(CurrentUser.CurrentEvent);
                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to set event code");
                return false;
            }
        }

        public async Task<(Category, Question)> AssignNewQuestion(string categoryCode) {
            if(categoryCode == null) {
                return (null, null);
            }
            if(CurrentUser == null) {
                throw new InvalidOperationException("No current user is set");
            }
            if(CurrentUser.CurrentEvent == null) {
                throw new InvalidOperationException("Cannot assign question if current event is not set");
            }

            try {
                var taskCategory = _storage.FetchCategory(CurrentUser.CurrentEvent, categoryCode);
                var taskQuestion = _storage.FetchRandomQuestion(CurrentUser.CurrentEvent, categoryCode);
                await Task.WhenAll(taskCategory, taskQuestion);

                if(taskCategory == null || taskQuestion == null) {
                    _logger.LogWarning("Could not load category {0} or random question", categoryCode);
                    return (null, null);
                }

                CurrentUser.State = (int)BotState.WaitingForQuizAnswer;
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                await _storage.UpdateUser(CurrentUser,
                    User.StateProp,
                    User.LastUpdateOnProp
                );

                return (taskCategory.Result, taskQuestion.Result);
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to assign question");
                return (null, null);
            }
        }

        public async Task<bool> AssignNewDestination(string coordinate, string code) {
            if (CurrentUser == null) {
                return false;
            }

            try {
                CurrentUser.State = (int)BotState.WaitingForLocation;
                CurrentUser.NextTargetCoordinate = coordinate;
                CurrentUser.NextTargetCode = code;
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                await _storage.UpdateUser(CurrentUser,
                    User.StateProp,
                    User.NextTargetCoordinateProp,
                    User.NextTargetCodeProp,
                    User.LastUpdateOnProp
                );

                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to assign new destination");
                return false;
            }
        }

        public async Task<bool> RegisterMove(GridCoordinate coordinate) {
            if (CurrentUser == null) {
                return false;
            }

            try {
                var newMoves = new List<string>(CurrentUser.Moves ?? Array.Empty<string>());
                newMoves.Add(coordinate.ToString());

                CurrentUser.Moves = newMoves.ToArray();
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                await _storage.UpdateUser(CurrentUser,
                    User.MovesProp,
                    User.LastUpdateOnProp
                );

                return true;
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Failed to register move");
                return false;
            }
        }

        public async Task<bool> SetMemory(string key, object value) {
            if (CurrentUser == null) {
                return false;
            }

            try {
                if(CurrentUser.Memory == null) {
                    CurrentUser.Memory = new Dictionary<string, object>();
                }
                CurrentUser.Memory[key] = value;
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                await _storage.UpdateUser(CurrentUser,
                    User.MemoryProp,
                    User.LastUpdateOnProp
                );

                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to update memory");
                return false;
            }
        }

        public async Task<bool> ClearMemory(string key) {
            if (CurrentUser == null) {
                return false;
            }

            try {
                if (CurrentUser.Memory != null) {
                    CurrentUser.Memory.Remove(key);
                }
                CurrentUser.LastUpdateOn = DateTime.UtcNow;
                await _storage.UpdateUser(CurrentUser,
                    User.MemoryProp,
                    User.LastUpdateOnProp
                );

                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to update memory");
                return false;
            }
        }

        public T GetMemory<T>(string key) where T : class {
            if(CurrentUser == null || CurrentUser.Memory == null) {
                return default;
            }
            if(!CurrentUser.Memory.ContainsKey(key)) {
                return default;
            }
            return (T)CurrentUser.Memory[key];
        }

        public T GetMemory<T>(string key, T defValue)
        {
            if (CurrentUser == null || CurrentUser.Memory == null)
            {
                return defValue;
            }
            if (!CurrentUser.Memory.ContainsKey(key))
            {
                return defValue;
            }
            return (T)CurrentUser.Memory[key];
        }

    }

}
