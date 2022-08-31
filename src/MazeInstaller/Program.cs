using CodyMazeBot;
using MazeInstaller;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello!");

var loggerFactory = new LoggerFactory();

Storage s = new(loggerFactory.CreateLogger<Storage>());

await NeoConnessiInstaller.Install(s);

Console.WriteLine("All done.");
