using BalloonsPopConsoleApp.Engine;
using BalloonsPopConsoleApp.Factories;
using BalloonsPopConsoleApp.Logs;
using BalloonsPopConsoleApp.UI.ConsoleUI;

namespace BalloonsPopConsoleApp
{
    class Program
    {
        static void Main()
        {
            const int boardSize = 10;

            var engineDependencies = new GameEngineDependencies(
                new ConsoleUserInterface(),
                new Constraints(1, 4, boardSize, boardSize),
                new Logger(),
                new Board(boardSize, boardSize),
                new BoardMemory(), 
                new CommandFactory(), 
                new CommandContextFactory()
                );

            var engine = new GameEngine(engineDependencies);

            engine.Start();
        }
    }
}
