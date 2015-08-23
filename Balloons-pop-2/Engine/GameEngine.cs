using System;
using BalloonsPops.Commands;
using BalloonsPops.UI;

namespace BalloonsPops.Engine
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
        private int userMoves;
        private int ballonsCount;

        public GameEngine(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public void Initialize()
        {
            // TODO: Generate board, initialize player stats
            throw new NotImplementedException();
        }

        public void Start()
        {
            // TODO: Initialize()
            throw new NotImplementedException();
        }

        public void Restart()
        {
            // TODO: Start()
            throw new NotImplementedException();
        }

        public void HandleCommands(ICommand command)
        {
            throw new NotImplementedException();
        }

        public void ExecuteTurn()
        {
            // TODO: HandleCommands(command), increment userMoves, clear screen, redraw
            throw new NotImplementedException();
        }
    }
}