namespace BalloonsPopConsoleApp
{
    using Engine;
    using Factories;
    using Logs;
    using UI.ConsoleUI;
    using Memory;
    using Miscellaneous;
    using Models;

    public class Program
    {
        private static void Main()
        {
            const int BoardSize = 10;

            var engineDependencies = new GameEngineDependencies(
                new ConsoleUserInterface(),
                new Logger(),
                new Board(BoardSize, BoardSize),
                new BoardMemory(),
                new CommandFactory());

            var engine = new GameEngine(engineDependencies);

            engine.Run();
        }
    }
}
