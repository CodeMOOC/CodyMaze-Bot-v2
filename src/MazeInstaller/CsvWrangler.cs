using System.Globalization;

namespace MazeInstaller {
    internal class CsvWrangler {
        public static void DoStuff(string category, string sourcePath, string outputPath) {
            var conf = new CsvHelper.Configuration.CsvConfiguration(new CultureInfo("it-IT")) {
                HasHeaderRecord = false,
            };
            using var reader = new CsvHelper.CsvReader(new StreamReader(sourcePath), conf);
            using var writer = new StreamWriter(outputPath);

            writer.WriteLine($"await Util.AddCategory(s, EventName, \"{category}\", Util.EngItaPor(\"\", \"\", \"\"),");

            while (reader.Read()) {
                if(string.IsNullOrEmpty(reader.GetField(0))) {
                    break;
                }

                writer.WriteLine("\tnew CodyMazeBot.StoreModels.Question {");
                writer.WriteLine("\t\tQuestionText = Util.EngItaPor(");
                writer.WriteLine("\t\t\t\"{0}\",", reader.GetField(0).Trim().Capitalize());
                writer.WriteLine("\t\t\t\"{0}\",", reader.GetField(4).Trim().Capitalize());
                writer.WriteLine("\t\t\t\"{0}\"", reader.GetField(8).Trim().Capitalize());
                writer.WriteLine("\t\t),");
                writer.WriteLine("\t\tAnswers = [");
                writer.WriteLine("\t\t\tUtil.EngItaPor(");
                writer.WriteLine("\t\t\t\t\"{0}\",", reader.GetField(1).Trim().Capitalize());
                writer.WriteLine("\t\t\t\t\"{0}\",", reader.GetField(5).Trim().Capitalize());
                writer.WriteLine("\t\t\t\t\"{0}\"", reader.GetField(9).Trim().Capitalize());
                writer.WriteLine("\t\t\t),");
                writer.WriteLine("\t\t\tUtil.EngItaPor(");
                writer.WriteLine("\t\t\t\t\"{0}\",", reader.GetField(2).Trim().Capitalize());
                writer.WriteLine("\t\t\t\t\"{0}\",", reader.GetField(6).Trim().Capitalize());
                writer.WriteLine("\t\t\t\t\"{0}\"", reader.GetField(10).Trim().Capitalize());
                writer.WriteLine("\t\t\t),");
                writer.WriteLine("\t\t\tUtil.EngItaPor(");
                writer.WriteLine("\t\t\t\t\"{0}\",", reader.GetField(3).Trim().Capitalize());
                writer.WriteLine("\t\t\t\t\"{0}\",", reader.GetField(7).Trim().Capitalize());
                writer.WriteLine("\t\t\t\t\"{0}\"", reader.GetField(11).Trim().Capitalize());
                writer.WriteLine("\t\t\t),");
                writer.WriteLine("\t\t]");
                writer.WriteLine("\t},");
            }

            writer.WriteLine(");");
        }
    }
}
