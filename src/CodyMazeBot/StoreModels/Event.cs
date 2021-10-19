using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot.StoreModels {
    [FirestoreData]
    public class Event {
        [FirestoreDocumentId]
        public string Code { get; set; }

        [FirestoreProperty("title")]
        public Dictionary<string, string> Title { get; set; }

        [FirestoreProperty("grid")]
        public Dictionary<string, GridCell> Grid { get; set; }
    }

    [FirestoreData]
    public class GridCell {
        [FirestoreProperty("category")]
        public string CategoryCode { get; set; }

        [FirestoreProperty("star")]
        public bool HasStar { get; set; }
    }
}
