using Google.Cloud.Firestore;

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
