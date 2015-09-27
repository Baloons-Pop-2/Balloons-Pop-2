using System;
using System.Collections.Generic;
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

        private void HandleCommands(string input, string[] parsedInput)
        {
            var instruction = parsedInput.Length == 0 ? string.Empty : parsedInput[0];

            ICommandContext ctx = this.commandContextFactory.GetNullCommandContext();

            var validInstructions = new Dictionary<string, Action<string[]>>()
            {
                {
                    "pop", delegate(string[] s)
                    {
                        var row = int.Parse(s[1]);
                        var col = int.Parse(s[2]);


                        ctx = this.commandContextFactory.GetPopCommandContext(this.board, row, col);
                    }
                },
                {
                    "undo", delegate(string[] s)
                    {
                        ctx = this.commandContextFactory.GetMementoCommandContext(this.board, this.memory);
                    }
                },
                {
                    "exit", delegate(string[] s)
                    {
                        ctx = this.commandContextFactory.GetNullCommandContext();
                    }
                },
                {
                    "restart", delegate(string[] s)
                    {
                        this.userMoves = 0;

                        ctx = this.commandContextFactory.GetBoardCommandContext(this.board);
                    }
                }
            };

            if (validInstructions.ContainsKey(instruction))
            {
                var command = this.commandFactory.GetCommand(instruction);

                validInstructions[instruction](parsedInput);

                if (command.CanExecute(ctx))
                {
                    this.memory.Memento = this.board.SaveMemento();
                    command.Execute(ctx);

                    this.userMoves++;

                    this.drawer.Clear();
                    this.drawer.Draw(this.board);
                }
                else                   
                {
                    command.Execute(ctx);

                    this.drawer.Clear();
                    this.drawer.Draw(this.board);
                    this.drawer.Draw(InvalidMove);
                }
            }
            else
            {
                this.drawer.Clear();
                this.drawer.Draw(this.board);
                this.drawer.Draw(InvalidCommand);
                this.logger.Log(input);
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

            this.Start();
        }

        private void ExecuteTurn()
        {
            this.drawer.Draw(InputPrompt);

            string input = this.reader.Read().Trim();
            string[] parsedInput = this.reader.ParseInput(input).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            this.HandleCommands(input, parsedInput);
        }
    }
}