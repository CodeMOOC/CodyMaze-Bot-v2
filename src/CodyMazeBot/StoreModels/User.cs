using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot.StoreModels {
    [FirestoreData]
    public class User {
        public const string NameProp = "name";
        public const string StateProp = "state";
        public const string FirstSeenOnProp = "firstSeen";
        public const string LastUpdateOnProp = "lastUpdate";
        public const string LanguageCodeOverrideProp = "languageCode";
        public const string MemoryProp = "memory";
        public const string CurrentEventProp = "currentEvent";
        public const string NextTargetCoordinateProp = "nextTargetCoordinate";
        public const string NextTargetCodeProp = "nextTargetCode";
        public const string PartialCoordinateProp = "partialCoordinate";
        public const string MovesProp = "moves";
        public const string PreviousStateProp = "previousState";

        [FirestoreDocumentId]
        public string UserId { get; set; }

        [FirestoreProperty(NameProp)]
        public string Name { get; set; }

        [FirestoreProperty(StateProp)]
        public int State { get; set; }

        [FirestoreProperty(FirstSeenOnProp)]
        public DateTime FirstSeenOn { get; set; } = DateTime.UtcNow;

        [FirestoreProperty(LastUpdateOnProp)]
        public DateTime LastUpdateOn { get; set; } = DateTime.UtcNow;

        [FirestoreProperty(LanguageCodeOverrideProp)]
        public string LanguageCodeOverride { get; set; }

        [FirestoreProperty(MemoryProp)]
        public Dictionary<string, object> Memory { get; set; }

        [FirestoreProperty(CurrentEventProp)]
        public string CurrentEvent { get; set; }

        [FirestoreProperty(NextTargetCoordinateProp)]
        public string NextTargetCoordinate { get; set; }

        [FirestoreProperty(NextTargetCodeProp)]
        public string NextTargetCode { get; set; }

        [FirestoreProperty(PartialCoordinateProp)]
        public string PartialCoordinate { get; set; }

        [FirestoreProperty(MovesProp)]
        public string[] Moves { get; set; } = Array.Empty<string>();

        public int MoveCount {
            get {
                if(Moves == null) {
                    return 0;
                }
                return Moves.Length;
            }
        }

        public GridCoordinate? LastMoveCoordinate {
            get {
                if(Moves == null || Moves.Length == 0) {
                    return null;
                }
                if(!GridCoordinate.TryParse(Moves[^1], out var ret)) {
                    return null;
                }
                return ret;
            }
        }

        [FirestoreProperty(PreviousStateProp)]
        public int? PreviousState { get; set; }
    }
}
