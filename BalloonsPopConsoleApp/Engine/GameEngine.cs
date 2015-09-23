using System;
using System.Linq;
using BalloonsPop;
using BalloonsPop.Commands;
using BalloonsPop.UI;
using BalloonsPop.UI.Drawer;
using BalloonsPop.UI.InputHandler;
using BalloonsPopConsoleApp.Factories;
using BalloonsPopConsoleApp.Logs;
using BalloonsPopConsoleApp.UI.ConsoleUI;

namespace BalloonsPopConsoleApp.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly ILogger logger;
        private const string WelcomeMessage = "Welcome to \"Balloons Pops\" game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private const string GoodbyeMessage = "Goodbye!";
        private const string InputPrompt = "Enter a row and column: ";
        private const string InvalidMove = "Illegal move: cannot pop missing ballon!";
        private const string InvalidCommand = "Invalid move or command!";
        private const string GameCompleteMessagePrompt = "You popped all baloons in {0} moves.\r\nPlease enter your name for the top scoreboard: ";

        private readonly IUserInterface userInterface;
        private readonly IPicasso drawer;
        private readonly IInputHandler reader;
        private readonly IConstraints constraints;
        private int userMoves;
        private IBoard board;
        private readonly ICommandFactory commandFactory;

        private IBoardMemory memory;

        public GameEngine(IUserInterface userInterface)
        {
            if (userInterface == null)
            {
                this.userInterface = new ConsoleUserInterface();
            }

            this.memory = new BoardMemory();

            this.constraints = new Constraints(1, 4, 10, 10);
            this.userInterface = userInterface;
            this.drawer = this.userInterface.Drawer;
            this.reader = this.userInterface.Reader;
            this.logger = new Logger();

            this.commandFactory = new CommandFactory();
        }

        private void Initialize()
        {
            // TODO: Generate board, initialize player stats
            // Partially implemented

            // TODO:
            // May ask for user input concerning board size

            this.board = new Board(this.constraints.BoardRows, this.constraints.BoardColumns);
            this.userMoves = 0;
        }

        public void Start()
        {
            // TODO: Initialize()
            // Partially implemented

            Initialize();
            this.drawer.Draw(WelcomeMessage);
            this.drawer.Draw(this.board);

            Play();
        }

        public void Restart()
        {
            // TODO: Start()
            throw new NotImplementedException();
        }

        private void HandleCommands(ICommand command)
        {
            throw new NotImplementedException();
        }

        private void Play()
        {
            while (true)
            {
                ExecuteTurn();
            }
        }

        private void ExecuteTurn()
        {
            // TODO: HandleCommands(command), increment userMoves, clear screen, redraw
            // Partially implemented
            // Currently not a viable and optimal solution to running the game, should consider using a loop

            this.drawer.Draw(InputPrompt);

            string input = this.reader.Read();
            string[] parsedInput = this.reader.ParseInput(input).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var instruction = parsedInput.Length == 0 ? string.Empty : parsedInput[0];
            ICommandContext ctx = new NullCommandContext();

            if (instruction == "")
            {
                this.drawer.Clear();
                this.drawer.Draw(this.board);
                this.drawer.Draw(InvalidCommand);
                this.logger.Log(input);
            }
            else
            {
                if (instruction == "undo")
                {
                    ctx = new CommandContext(this.board, this.memory);
                }

                if (instruction == "pop")
                {
                    this.memory.Memento = this.board.SaveMemento();

                    var row = int.Parse(parsedInput[1]);
                    var col = int.Parse(parsedInput[2]);

                    ctx = new CommandContext(this.board, row, col);
                }

                // HandleCommands
                var command = this.commandFactory.GetCommand(instruction);

                command.Execute(ctx);

                this.drawer.Clear();
                this.drawer.Draw(this.board);
            }
        }
    }
}