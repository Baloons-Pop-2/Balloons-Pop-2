namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;
    using BalloonsPop.Logs;
    using BalloonsPop.UI;

    /// <summary>
    /// Dependancies injected into the operating class's constructor (Game Engine)
    /// </summary>
    public class GameEngineDependencies
    {
        /// <summary>
        /// GameEngineDependencies constructor
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="logger"></param>
        /// <param name="board"></param>
        /// <param name="memory"></param>
        /// <param name="commandFactory"></param>
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
