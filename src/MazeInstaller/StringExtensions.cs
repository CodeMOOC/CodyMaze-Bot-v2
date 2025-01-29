namespace MazeInstaller {
    internal static class StringExtensions {
        public static string Capitalize(this string str) {
            if (str == null) {
                return null;
            }

            if (str.Length == 0) {
                return string.Empty;
            }

            return char.ToUpperInvariant(str[0]) + str.Substring(1);
        }
    }
}
