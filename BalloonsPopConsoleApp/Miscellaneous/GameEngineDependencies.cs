// <copyright  file="GameEngineDependencies.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;
    using BalloonsPop.Logs;
    using BalloonsPop.UI;

    /// <summary>
    /// Dependencies injected into the operating class's constructor (Game Engine)
    /// </summary>
    public class GameEngineDependencies
    {
        /// <summary>
        /// GameEngineDependencies object injects objects through dependency inversion in an object
        /// </summary>
        /// <param name="ui">The user interface to be used</param>
        /// <param name="logger">The logger to save messages</param>
        /// <param name="board">The board object to be used in the game</param>
        /// <param name="memory">The memory caretaker where a memento is saved</param>
        /// <param name="commandFactory">The factory through which flyweight commands are acquired</param>
        public GameEngineDependencies(IUserInterface ui, ILogger logger, IBoard board, IBoardMemory memory, ICommandFactory commandFactory)
        {
            this.UserInterface = ui;
            this.Logger = logger;
            this.Board = board;
            this.BoardMemory = memory;
            this.CommandFactory = commandFactory;
            //// TODO:
            //// SCORE!!!
        }

        /// <summary>
        /// Provides the public interface used by the operating class. Contains IPicasso and IReader.
        /// </summary>
        public IUserInterface UserInterface { get; private set; }

        /// <summary>
        /// Logger logs messages runtime.
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Board object containing Balloon objects.
        /// </summary>
        public IBoard Board { get; private set; }

        /// <summary>
        /// Memory object where a memento is stored.
        /// </summary>
        public IBoardMemory BoardMemory { get; private set; }

        /// <summary>
        /// Factory object that returns ICommand objects used by the operating class.
        /// </summary>
        public ICommandFactory CommandFactory { get; private set; }
    }
}
