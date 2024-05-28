using CodyMazeBot;
using MazeInstaller;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello!");

var loggerFactory = new LoggerFactory();

Storage s = new(loggerFactory.CreateLogger<Storage>());

IInstaller installer = new GiornataDelGiocoUrbinoInstaller();
await installer.Install(s);

Console.WriteLine("All done.");
