// <copyright  file="Program.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp
{
    using Engine;
    using Factories;
    using Logs;
    using Memory;
    using Miscellaneous;
    using Models;
    using UI.ConsoleUI;

    public class Program
    {
        private static void Main()
        {
            const int BoardSize = 10;

            var engineDependencies = new GameEngineDependencies(
                new ConsoleUserInterface(),
                new Logger(),
                new Board(BoardSize, BoardSize, new RandomGenerator()),
                new BoardMemory(),
                new CommandFactory());

            var engine = new GameEngine(engineDependencies);

            engine.Run();
        }
    }
}
