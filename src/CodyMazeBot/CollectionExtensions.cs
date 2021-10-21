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
            if(source.ContainsKey("it")) {
                return source["it"];
            }
            if(source.Count > 0) {
                return source.First().Value;
            }
            return "???";
        }

        /// <summary>
        /// Gets whether this localization map can return a meaningful translation.
        /// </summary>
        public static bool CanLocalize(this IDictionary<string, string> source) {
            if(source == null) {
                return false;
            }
            if(source.Count == 0) {
                return false;
            }
            return true;
        }

    }
}
