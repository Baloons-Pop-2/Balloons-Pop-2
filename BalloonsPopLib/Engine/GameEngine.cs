using System;
using BalloonsPop.Commands;
using BalloonsPop.UI;
using BalloonsPop.UI.ConsoleUI;
using BalloonsPop.UI.Drawer;
using BalloonsPop.UI.InputHandler;
using BalloonsPop.UI.ScoreBoard;

namespace BalloonsPop.Engine
{
    public class GameEngine : IGameEngine
    {
        private const string WelcomeMessage = "Welcome to \"Balloons Pops\" game. Please try to pop the balloons. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        private const string GoodbyeMessage = "Goodbye!";
        private const string InputPrompt = "Enter a row and column: ";
        private const string InvalidMove = "Illegal move: cannot pop missing ballon!";
        private const string InvalidCommand = "Invalid move or command!";
        private const string GameCompleteMessagePrompt = "You popped all baloons in {0} moves.\r\nPlease enter your name for the top scoreboard: ";

        private IUserInterface userInterface;
        private readonly IPicasso drawer;
        private readonly IInputHandler reader;
        private int userMoves;
        private int ballonsCount;
        private IBoard board;
        private ICommand popCommand;
        private HighScore highscore;

        public GameEngine(IUserInterface userInterface)
        {
            if (userInterface == null)
            {
                this.userInterface = new ConsoleUserInterface();
            }

            this.userInterface = userInterface;
            this.drawer = this.userInterface.Drawer;
            this.reader = this.userInterface.Reader;

            this.popCommand = new PopBalloonCommand();
        }

        public void Initialize()
        {
            // TODO: Generate board, initialize player stats
            // Partially implemented

            // TODO:
            // May ask for user input concerning board size

            this.board = new Board(10, 10);
            this.userMoves = 0;
            this.ballonsCount = 0;
            this.highscore = new HighScore();
        }

        public void Start()
        {
            // TODO: Initialize()
            // Partially implemented

            Initialize();
            this.drawer.Draw(WelcomeMessage);
            this.drawer.Draw(this.board);

            ExecuteTurn();

            //// TODO: Implement - When finish the game
            //var currentResult = new ScoreResult(username, moves);
            //highscore.AddScore(currentResult);
            //// END "TODO: Implement"
        }

        public void Restart()
        {
            // TODO: Start()
            throw new NotImplementedException();
        }

        public void HandleCommands(ICommand command)
        {
            throw new NotImplementedException();

            // When enter 'top'
            //this.highscore.Ranking();
        }

        public void ExecuteTurn()
        {
            // TODO: HandleCommands(command), increment userMoves, clear screen, redraw
            // Partially implemented
            // Currently not a viable and optimal solution to running the game, should consider using a loop

            this.drawer.Draw(InputPrompt);

            string input = this.reader.Read();
            var coords = input.Split(' ');
            var row = int.Parse(coords[0]);
            var col = int.Parse(coords[1]);

            // HandleCommands
            var ctx = new CommandContext(this.board, row, col);
            popCommand.Execute(ctx);
            this.drawer.Clear();
            this.drawer.Draw(this.board);
            ExecuteTurn();
        }
    }
}