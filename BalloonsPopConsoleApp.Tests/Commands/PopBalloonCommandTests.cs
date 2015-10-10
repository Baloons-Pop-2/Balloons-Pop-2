namespace BalloonsPopConsoleApp.Tests.Commands
{
    using System;
    using BalloonsPopConsoleApp.Commands;
    using BalloonsPopConsoleApp.Logs;
    using Memory;
    using BalloonsPopConsoleApp.Miscellaneous;
    using NUnit.Framework;

    [TestFixture]
    public class PopBalloonCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CommandWithProperInvalidBoardShouldThrow()
        {
            var cmd = new PopBalloonCommand();

            var ctx = new CommandContext(new Logger(), null, 2, 2, new BoardMemory(), Highscore.GetInstance(), new HighscoreProcessor());

            cmd.Execute(ctx);
        }
    }
}
