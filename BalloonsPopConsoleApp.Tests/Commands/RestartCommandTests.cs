using BalloonsPop;
using BalloonsPopConsoleApp.Commands;
using BalloonsPopConsoleApp.Logs;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopConsoleApp.Tests.Commands
{
    [TestFixture]
    public class RestartCommandTests
    {
        [Test]
        public void ShouldResetBoard()
        {
            int initialBalloonsCount = 16;
            int beforeReset;
            int afterReset;

            Dictionary<string, string> messages = new Dictionary<string, string> { { RestartCommand.WelcomeMessageKey, "welcome" } };
            var boardMock = new Mock<IBoard>();
            boardMock.SetupGet(x => x.UnpoppedBalloonsCount)
                .Returns(initialBalloonsCount);
            boardMock.Setup(x => x.Reset())
                .Callback(() =>
            {
                boardMock.SetupGet(x => x.UnpoppedBalloonsCount)
                    .Returns(initialBalloonsCount * 2);
            });

            var board = boardMock.Object;
            beforeReset = board.UnpoppedBalloonsCount;

            var scoreMock = new Mock<IHighscore>();
            var logger = new Logger();
            var restartCommand = new RestartCommand();

            var ctx = new Mock<ICommandContext>();
            ctx.SetupGet(x => x.Board).Returns(board);
            ctx.SetupGet(x => x.Messages).Returns(messages);
            ctx.SetupGet(x => x.Score).Returns(scoreMock.Object);
            ctx.SetupGet(x => x.Logger).Returns(logger);
            restartCommand.Execute(ctx.Object);

            afterReset = board.UnpoppedBalloonsCount;

            Assert.AreEqual(beforeReset * 2, afterReset);
        }
    }
}
