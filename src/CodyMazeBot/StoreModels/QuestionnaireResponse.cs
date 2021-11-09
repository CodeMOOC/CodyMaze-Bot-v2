using Google.Cloud.Firestore;
using System;

namespace CodyMazeBot.StoreModels
{
    [FirestoreData]
    public class QuestionnaireResponse
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        [FirestoreProperty("responses")]
        public string[] Responses { get; set; }

        [FirestoreProperty("userId")]
        public string UserId { get; set; }

        [FirestoreProperty("userFirstSeen")]
        public DateTime UserFirstSeen { get; set; }

        [FirestoreProperty("userName")]
        public string UserName { get; set; }

        [FirestoreProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
