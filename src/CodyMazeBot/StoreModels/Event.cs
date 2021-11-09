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

        [FirestoreProperty("questionnaire")]
        public Questionnaire Questionnaire { get; set; }
    }

    [FirestoreData]
    public class GridCell {
        [FirestoreProperty("category")]
        public string CategoryCode { get; set; }

        [FirestoreProperty("star")]
        public bool HasStar { get; set; }
    }

    [FirestoreData]
    public class Questionnaire {
        [FirestoreProperty("questions")]
        public QuestionnaireQuestion[] Questions { get; set; }
    }

    [FirestoreData]
    public class QuestionnaireQuestion
    {
        [FirestoreProperty("kind")]
        public string Kind { get; set; }

        [FirestoreProperty("text")]
        public Dictionary<string, string> Text { get; set; }

        [FirestoreProperty("answers")]
        public Dictionary<string, string>[] Answers{ get; set; }
    }
}
