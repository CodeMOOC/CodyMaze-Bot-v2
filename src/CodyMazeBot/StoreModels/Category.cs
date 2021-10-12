using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot.StoreModels {
    [FirestoreData]
    public class Category {
        [FirestoreDocumentId]
        public string Code { get; set; }

        [FirestoreProperty("title")]
        public Dictionary<string, string> Title { get; set; }
    }
}
