namespace BalloonsPopConsoleApp
{
    using Engine;
    using Factories;
    using Logs;
    using UI.ConsoleUI;

    public class Program
    {
        private static void Main()
        {
            const int BoardSize = 8;

            var engineDependencies = new GameEngineDependencies(
                new ConsoleUserInterface(),
                new Constraints(BoardSize, BoardSize),
                new Logger(),
                new Board(BoardSize, BoardSize),
                new BoardMemory(),
                new CommandFactory());

            var engine = new GameEngine(engineDependencies);

            engine.Run();
        }
    }
}
