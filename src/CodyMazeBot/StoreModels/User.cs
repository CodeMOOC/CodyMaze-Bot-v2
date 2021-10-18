using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot.StoreModels {
    [FirestoreData]
    public class User {
        [FirestoreDocumentId]
        public string UserId { get; set; }

        public const string NameProp = "name";

        [FirestoreProperty(NameProp)]
        public string Name { get; set; }

        public const string StateProp = "state";

        [FirestoreProperty(StateProp)]
        public int State { get; set; }

        [FirestoreProperty("firstSeen")]
        public DateTime FirstSeenOn { get; set; } = DateTime.UtcNow;

        public const string LastUpdateOnProp = "lastUpdate";

        [FirestoreProperty(LastUpdateOnProp)]
        public DateTime LastUpdateOn { get; set; } = DateTime.UtcNow;

        public const string LanguageCodeOverrideProp = "languageCode";

        [FirestoreProperty(LanguageCodeOverrideProp)]
        public string LanguageCodeOverride { get; set; }

        [FirestoreProperty("memory")]
        public Dictionary<string, object> Memory { get; set; }

        public const string PreviousStateProp = "previousState";

        [FirestoreProperty(PreviousStateProp)]
        public int? PreviousState { get; set; }
    }
}
