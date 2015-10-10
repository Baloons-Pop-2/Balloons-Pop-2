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

    /// <summary>
    /// Balloons Pop-2 Program - A game is initialized with its components, ran in a loop and then terminated.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point for the Balloons Pop-2 game.
        /// </summary>
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
