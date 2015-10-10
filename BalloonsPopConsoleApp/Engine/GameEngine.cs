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

    public class GameEngine : IGameEngine
    {
        private readonly IUserInterface userInterface;
        private readonly IPicasso drawer;
        private readonly IInputHandler reader;
        private readonly ICommandFactory commandFactory;
        private readonly ICommandContext ctx;

        public GameEngine(GameEngineDependencies dependencies)
        {
            this.userInterface = dependencies.UserInterface;
            this.drawer = this.userInterface.Drawer;
            this.reader = this.userInterface.Reader;

            this.commandFactory = dependencies.CommandFactory;

            this.ctx = new CommandContext(dependencies.Logger, new Board(dependencies.Board.Rows, dependencies.Board.Cols, new RandomGenerator()), 0, 0, dependencies.BoardMemory, Highscore.GetInstance(), new HighscoreProcessor());
        }

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

        private void HandleHighcores()
        {
            this.drawer.Draw(this.ctx.Messages["usernameprompt"]);
            var username = this.reader.Read();

            this.ctx.Score.SetMoves(this.ctx.Score.CurrentMoves).SetUsername(username).SetScore(this.ctx.Board.Rows);
            this.ctx.HighscoreProcessor.SaveHighscore(this.ctx.Score);
        }

        private void RedefineBoardSize()
        {
            var size = this.reader.Read();

            if (size == "invalidInput")
            {
                return;
            }

            try
            {
                var intSize = int.Parse(size);
                this.ctx.Board = new Board(intSize, intSize, new RandomGenerator());
            }
            catch (Exception)
            {
                this.ctx.CurrentMessage = "\nDefault size initialized!";
            }
        }

        private void GameOver()
        {
            this.drawer.Draw(this.ctx.Messages["goodbye"]);
        }

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