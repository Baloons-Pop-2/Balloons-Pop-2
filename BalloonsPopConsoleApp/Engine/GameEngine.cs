using System;
using System.Linq;
using BalloonsPop;
using BalloonsPop.UI;
using BalloonsPop.UI.Drawer;
using BalloonsPop.UI.InputHandler;
using BalloonsPopConsoleApp.Logs;

namespace BalloonsPopConsoleApp.Engine
{
    public class GameEngine : IGameEngine
    {
        private const string WelcomeMessage = "Welcome to \"Balloons Pops\" game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private const string GoodbyeMessage = "Goodbye!";
        private const string InputPrompt = "Enter a row and column or a command: ";
        private const string InvalidMove = "Illegal move: cannot pop missing ballon!";
        private const string InvalidCommand = "Invalid move or command!";
        private const string GameCompleteMessagePrompt = "You popped all baloons in {0} moves.\r\nPlease enter your name for the top scoreboard: ";

        private readonly IUserInterface userInterface;
        private readonly IPicasso drawer;
        private readonly IInputHandler reader;
        private readonly IConstraints constraints;
        private readonly ILogger logger;
        private readonly ICommandFactory commandFactory;
        private readonly ICommandContextFactory commandContextFactory;
        private readonly IBoardMemory memory;
        private IBoard board;

        private int userMoves;

        public GameEngine(GameEngineDependencies dependencies)
        {
            this.userInterface = dependencies.UserInterface;
            this.drawer = this.userInterface.Drawer;
            this.reader = this.userInterface.Reader;

            this.memory = dependencies.BoardMemory;
            this.logger = dependencies.Logger;

            this.constraints = dependencies.Constraints;

            this.commandFactory = dependencies.CommandFactory;
            this.commandContextFactory = dependencies.CommandContextFactory;
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

        private void HandleCommands(string input, string[] parsedInput)
        {
            var instruction = parsedInput.Length == 0 ? string.Empty : parsedInput[0];
            var ctx = this.commandContextFactory.GetNullCommandContext(this.board);

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
                    ctx = this.commandContextFactory.GetMementoCommandContext(this.board, this.memory);
                }

                if (instruction == "pop")
                {
                    this.memory.Memento = this.board.SaveMemento();

                    var row = int.Parse(parsedInput[1]);
                    var col = int.Parse(parsedInput[2]);

                    ctx = this.commandContextFactory.GetPopCommandContext(this.board, row, col);
                }

                var command = this.commandFactory.GetCommand(instruction);

                command.Execute(ctx);

                this.drawer.Clear();
                this.drawer.Draw(this.board);
            }
        }

        private void Play()
        {
            while (true)
            {
                if (this.board.UnpoppedBalloonsCount == 0)
                {
                    break;
                }
                ExecuteTurn();
            }

            GameOver();
        }

        private void GameOver()
        {
            this.drawer.Clear();
            this.drawer.Draw(string.Format(GameCompleteMessagePrompt, this.userMoves));
            this.reader.Read();
        }

        private void ExecuteTurn()
        {
            // TODO: HandleCommands(command), increment userMoves, clear screen, redraw

            this.drawer.Draw(InputPrompt);

            string input = this.reader.Read();
            string[] parsedInput = this.reader.ParseInput(input).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            this.HandleCommands(input, parsedInput);
            this.userMoves++;

        }
    }
}