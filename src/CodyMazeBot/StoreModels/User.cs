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

        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("state")]
        public int State { get; set; }

        [FirestoreProperty("firstSeen")]
        public DateTime FirstSeenOn { get; set; }

        [FirestoreProperty("lastUpdate")]
        public DateTime LastUpdateOn { get; set; }

        [FirestoreProperty("languageCode")]
        public string LanguageCodeOverride { get; set; }

        [FirestoreProperty("memory")]
        public Dictionary<string, object> Memory { get; set; }
    }
}
