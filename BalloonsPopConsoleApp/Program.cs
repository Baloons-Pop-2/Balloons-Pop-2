using System;
using BalloonsPopConsoleApp.Engine;
using BalloonsPopConsoleApp.Factories;
using BalloonsPopConsoleApp.Logs;
using BalloonsPopConsoleApp.UI.ConsoleUI;

namespace BalloonsPopConsoleApp
{
    class Program
    {
        private static void Main()
        {
            const int boardSize = 8;

            var engineDependencies = new GameEngineDependencies(
                new ConsoleUserInterface(),
                new Constraints(boardSize, boardSize),
                new Logger(),
                new Board(boardSize, boardSize),
                new BoardMemory(),
                new CommandFactory()
                );

            var engine = new GameEngine(engineDependencies);

            engine.Run();
        }
    }
}
