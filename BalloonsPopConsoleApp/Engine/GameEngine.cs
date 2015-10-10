// <copyright  file="GameEngine.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Engine
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Commands;
    using BalloonsPop.UI;
    using BalloonsPop.UI.Drawer;
    using BalloonsPop.UI.InputHandler;
    using Miscellaneous;
    using Models;

    /// <summary>
    /// The game engine - the entire game logic.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        /// <summary>
        /// The field that holds the IUserInterface instance.
        /// </summary>
        private readonly IUserInterface userInterface;

        /// <summary>
        /// The field that holds the IPicasso instance which draws the game.
        /// </summary>
        private readonly IPicasso drawer;

        /// <summary>
        /// The field that holds the IInputHandler instance which reads user input.
        /// </summary>
        private readonly IInputHandler reader;

        /// <summary>
        /// The field that holds the ICommandFactory instance which creates commands.
        /// </summary>
        private readonly ICommandFactory commandFactory;

        /// <summary>
        /// The field that holds the ICommandContext instance that is passed to the commands.
        /// </summary>
        private readonly ICommandContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine" /> class.
        /// </summary>
        /// <param name="dependencies">An object which holds the dependencies for the game engine.</param>
        public GameEngine(GameEngineDependencies dependencies)
        {
            this.userInterface = dependencies.UserInterface;
            this.drawer = this.userInterface.Drawer;
            this.reader = this.userInterface.Reader;

            this.commandFactory = dependencies.CommandFactory;

            this.ctx = new CommandContext(dependencies.Logger, new Board(dependencies.Board.Rows, dependencies.Board.Cols, new RandomGenerator()), 0, 0, dependencies.BoardMemory, Highscore.GetInstance(), new HighscoreProcessor());
        }

        /// <summary>
        /// The method that starts the game.
        /// </summary>
        public void Run()
        {
            this.drawer.Draw(this.ctx.Board);
            this.drawer.Draw(this.ctx.Messages["sizeprompt"]);
            this.RedefineBoardSize();

            while (this.ctx.Board.UnpoppedBalloonsCount > 0 && !this.ctx.IsOver)
            {
                this.drawer.Clear();
                this.drawer.Draw(this.ctx.Board);
                this.drawer.Draw(this.ctx.CurrentMessage);
                this.drawer.Draw(this.ctx.Messages["inputprompt"]);

                this.ExecuteTurn();
            }

            if (this.ctx.Board.UnpoppedBalloonsCount == 0)
            {
                this.HandleHighcores();
            }

            this.GameOver();
        }

        /// <summary>
        /// A method for handling high score's parsing and saving after the game has ended.
        /// </summary>
        private void HandleHighcores()
        {
            this.drawer.Draw(this.ctx.Messages["usernameprompt"]);
            var username = this.reader.Read();

            if (string.IsNullOrWhiteSpace(username))
            {
                username = "anonymous";
            }

            this.ctx.Score.SetMoves(this.ctx.Score.CurrentMoves).SetUsername(username).SetScore(this.ctx.Board.Rows);
            this.ctx.HighscoreProcessor.SaveHighscore(this.ctx.Score);
        }

        /// <summary>
        /// Defines a new board/restart.
        /// </summary>
        private void RedefineBoardSize()
        {
            var size = this.reader.Read();

            try
            {
                var intSize = int.Parse(size);
                this.ctx.Board = new Board(intSize, intSize, new RandomGenerator());
            }
            catch (Exception)
            {
                this.ctx.CurrentMessage = "\nDefault size initialized!\n";
            }
        }

        /// <summary>
        /// Draws the goodbye message.
        /// </summary>
        private void GameOver()
        {
            this.drawer.Draw(this.ctx.Messages["goodbye"]);
        }

        /// <summary>
        /// The method that is responsible for the turn logic - parses and dispatches commands.
        /// </summary>
        private void ExecuteTurn()
        {
            var input = this.reader.Read();
            var parsedInput = this.reader.ParseInput(input);
            var splitInput = parsedInput.Split(' ');

            ICommand command = this.commandFactory.GetCommand(splitInput[0]);

            if (splitInput.Length == 3)
            {
                this.ctx.ActiveRow = int.Parse(splitInput[1]);
                this.ctx.ActiveCol = int.Parse(splitInput[2]);

                if (this.ctx.Board.IsValidPop(this.ctx.ActiveRow, this.ctx.ActiveCol))
                {
                    this.ctx.Memory.Memento = this.ctx.Board.SaveMemento();
                }

                this.ctx.Score.SetMoves(this.ctx.Score.CurrentMoves + 1);
            }

            command.Execute(this.ctx);
        }
    }
}