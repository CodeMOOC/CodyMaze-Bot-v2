using Google.Cloud.Firestore;

namespace CodyMazeBot.StoreModels {
    [FirestoreData]
    public class Category {
        [FirestoreDocumentId]
        public string Code { get; set; }

        [FirestoreProperty("title")]
        public Dictionary<string, string> Title { get; set; }
    }
}
