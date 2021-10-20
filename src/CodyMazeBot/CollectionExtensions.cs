using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public static class CollectionExtensions {

        public static string Localize(this IDictionary<string, string> source) {
            if(source == null) {
                return "???";
            }

            string cultureCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if(source.ContainsKey(cultureCode)) {
                return source[cultureCode];
            }
            if(source.ContainsKey("en")) {
                return source["en"];
            }
            if(source.Count > 0) {
                return source.First().Value;
            }
            return "???";
        }

    }
}
