using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot.StoreModels {
    [FirestoreData]
    public class Question {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty("question")]
        public Dictionary<string, string> QuestionText { get; set; }

        [FirestoreProperty("answers")]
        public Dictionary<string, string>[] Answers { get; set; }
    }
}
