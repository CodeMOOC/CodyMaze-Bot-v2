using CodyMazeBot;
using MazeInstaller;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello!");

var loggerFactory = new LoggerFactory();

Storage s = new(loggerFactory.CreateLogger<Storage>());

IInstaller installer = new InafInstaller();
await installer.Install(s);

// string code = "instruments";
// CsvWrangler.DoStuff(code, $"C:\\Users\\loren\\Downloads\\EN_quiz_x_codymaze_traducao_PT_{code}.csv", "C:\\Users\\loren\\Downloads\\tmp.cs");

Console.WriteLine("All done.");
