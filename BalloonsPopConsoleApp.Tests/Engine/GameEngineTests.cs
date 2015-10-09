namespace BalloonsPopConsoleApp.Tests.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BalloonsPop.UI;
    using BalloonsPop.UI.Drawer;
    using BalloonsPop.UI.InputHandler;
    using BalloonsPopConsoleApp.Engine;
    using BalloonsPopConsoleApp.Logs;
    using BalloonsPopConsoleApp.Miscellaneous;
    using BalloonsPopConsoleApp.Models;

    using Factories;
    using Memory;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class GameEngineTests
    {
        [Test]
        public void GameEngineShouldStartUpCorrectlyAndExitWhenACommandIsProvided()
        {
            var mockedUi = new Mock<IUserInterface>();

            var mockedDrawer = new Mock<IPicasso>();
            mockedDrawer.Setup(x => x.Draw(It.IsAny<object>()))
                .Verifiable();
            mockedDrawer.Setup(x => x.Clear())
                .Verifiable();

            mockedUi.Setup(x => x.Drawer).Returns(mockedDrawer.Object);
            mockedUi.Setup(x => x.Reader).Returns(this.GetReader(new List<string> {"", "exit"}));

            var dependencies = new GameEngineDependencies(mockedUi.Object, new Logger(), new Board(5, 5), new BoardMemory(), new CommandFactory());

            var engine = new GameEngine(dependencies);
            engine.Run();
        }

        [Test]
        public void GameEngineShouldExecutePopCommandsCorrectlyWithoutCrashing()
        {
            var mockedUi = new Mock<IUserInterface>();

            var mockedDrawer = new Mock<IPicasso>();
            mockedDrawer.Setup(x => x.Draw(It.IsAny<object>()))
                .Verifiable();
            mockedDrawer.Setup(x => x.Clear())
                .Verifiable();

            mockedUi.Setup(x => x.Drawer).Returns(mockedDrawer.Object);
            mockedUi.Setup(x => x.Reader).Returns(this.GetReader(new List<string> {"", "4 4", "exit"}));

            var dependencies = new GameEngineDependencies(mockedUi.Object, new Logger(), new Board(5, 5), new BoardMemory(), new CommandFactory());

            var engine = new GameEngine(dependencies);
            engine.Run();
        }

        [Test]
        public void GameEngineSelecting5ShouldProperlySetBoardSizeTo5WhenInitiallyAsked()
        {
            var mockedUi = new Mock<IUserInterface>();

            var mockedDrawer = new Mock<IPicasso>();
            mockedDrawer.Setup(x => x.Draw(It.IsAny<object>()))
                .Verifiable();
            mockedDrawer.Setup(x => x.Clear())
                .Verifiable();

            mockedUi.Setup(x => x.Drawer).Returns(mockedDrawer.Object);
            mockedUi.Setup(x => x.Reader).Returns(this.GetReader(new List<string> { "5", "4 4", "exit" }));

            var dependencies = new GameEngineDependencies(mockedUi.Object, new Logger(), new Board(5, 5), new BoardMemory(), new CommandFactory());

            var engine = new GameEngine(dependencies);
            engine.Run();
        }

        // TODO: Not entirely tested as there should be a Highscore name prompt!
        [Test]
        public void GameEnginePoppingAllBalloonsShouldWinTheGame()
        {
            var mockedUi = new Mock<IUserInterface>();

            var mockedDrawer = new Mock<IPicasso>();
            mockedDrawer.Setup(x => x.Draw(It.IsAny<object>()))
                .Verifiable();
            mockedDrawer.Setup(x => x.Clear())
                .Verifiable();

            mockedUi.Setup(x => x.Drawer).Returns(mockedDrawer.Object);
            mockedUi.Setup(x => x.Reader).Returns(this.GetReader(new List<string>
            {
                "5", "4 0", "4 1", "4 2", "4 3", "4 4", "4 0", "4 1", "4 2", "4 3", "4 4", "4 0", "4 1", "4 2", "4 3", "4 4", "4 0", "4 1", "4 2", "4 3", "4 4", "4 0", "4 1", "4 2", "4 3", "4 4"
            }));

            var dependencies = new GameEngineDependencies(mockedUi.Object, new Logger(), new Board(5, 5), new BoardMemory(), new CommandFactory());

            var engine = new GameEngine(dependencies);
            engine.Run();
        }

        private IInputHandler GetReader(IList<string> input)
        {
            var i = 0;
            var numberOfCalls = input.Count;
            string parsedInput = "";
            var mockedReader = new Mock<IInputHandler>();
            mockedReader.Setup(x => x.Read()).Callback(() =>
            {
                if (i <= numberOfCalls - 1)
                {
                    var currentCommand = input[i];

                    if (string.IsNullOrWhiteSpace(currentCommand))
                    {
                        parsedInput = "invalidInput";
                    }
                    else
                    {
                        parsedInput = currentCommand;
                    }

                }
                else
                {
                    //parsedInput = "exit";
                }

                i++;
            })
            .Returns(() => parsedInput);

            string parsedString = "";

            mockedReader.Setup(x => x.ParseInput(It.IsAny<string>())).Callback((string y) =>
            {
                var splitInput = y.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (splitInput.Length == 2)
                {
                    if ((splitInput[0] + splitInput[1]).All(char.IsDigit))
                    {
                        parsedString = "pop " + splitInput[0] + " " + splitInput[1];
                    }
                    else
                    {
                        parsedString = "invalidInput";
                    }
                }
                else if (splitInput.Length == 1)
                {
                    if (splitInput[0] != "exit" && splitInput[0] != "undo" &&
                        splitInput[0] != "restart" && splitInput[0] != "top")
                    {
                        parsedString = "invalidInput";
                    }
                    else
                    {
                        parsedString = y;
                    }
                }
                else
                {
                    parsedString = "invalidInput";
                }
            })
            .Returns(() => parsedString);

            return mockedReader.Object;
        }
    }
}
