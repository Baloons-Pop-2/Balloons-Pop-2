namespace BalloonsPopConsoleApp.Miscellaneous
{
    using BalloonsPop;
    using BalloonsPop.Logs;
    using BalloonsPop.UI;

    public class GameEngineDependencies
    {
        public GameEngineDependencies(IUserInterface ui, IConstraints constraints, ILogger logger, IBoard board, IBoardMemory memory, ICommandFactory commandFactory)
        {
            this.UserInterface = ui;
            this.Constraints = constraints;
            this.Logger = logger;
            this.Board = board;
            this.BoardMemory = memory;
            this.CommandFactory = commandFactory;
            //// TODO:
            //// SCORE!!!
        }

        public IUserInterface UserInterface { get; private set; }

        public IConstraints Constraints { get; private set; }

        public ILogger Logger { get; private set; }

        public IBoard Board { get; private set; }

        public IBoardMemory BoardMemory { get; private set; }

        public ICommandFactory CommandFactory { get; private set; }
    }
}
