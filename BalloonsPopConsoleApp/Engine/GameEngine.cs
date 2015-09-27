using System;
using BalloonsPop;
using BalloonsPop.Commands;
using BalloonsPop.UI;
using BalloonsPop.UI.Drawer;
using BalloonsPop.UI.InputHandler;

namespace BalloonsPopConsoleApp.Engine
{
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

            this.ctx = new CommandContext(dependencies.Logger, 
                new Board(dependencies.Constraints.BoardRows, dependencies.Constraints.BoardColumns), 
                0, 0, 
                dependencies.BoardMemory, 
                new Highscore());
        }

        public void Run()
        {
            this.commandFactory.GetCommand("restart").Execute(this.ctx);
            this.drawer.Draw(this.ctx.Board);

            this.drawer.Draw(this.ctx.Messages["sizeprompt"]);
            RedefineBoardSize();

            while (this.ctx.Board.UnpoppedBalloonsCount > 0)
            {
                this.drawer.Clear();
                this.drawer.Draw(this.ctx.Board);
                this.drawer.Draw(this.ctx.CurrentMessage);
                this.drawer.Draw(this.ctx.Messages["inputprompt"]);

                ExecuteTurn();
            }

            GameOver();
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
                this.ctx.Board = new Board(intSize, intSize);
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

                this.ctx.Score.CurrentScore++;
            }

            command.Execute(this.ctx);
        }
    }
}