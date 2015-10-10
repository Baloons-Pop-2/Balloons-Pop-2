namespace BalloonsPopConsoleApp.Tests.Commands
{
    using BalloonsPopConsoleApp.Commands;
    using BalloonsPopConsoleApp.Logs;
    using Memory;
    using BalloonsPopConsoleApp.Miscellaneous;
    using BalloonsPopConsoleApp.Models;
    using NUnit.Framework;

    [TestFixture]
    public class UndoCommandTests
    {
        [Test]
        public void OnExecuteShouldInformPlayerThatAMementoIsNotAvailableWhenThereIsntOneSaved()
        {
            var ctx = new CommandContext(new Logger(), new Board(5, 5, new RandomGenerator()), 2, 2, new BoardMemory(), Highscore.GetInstance(), new HighscoreProcessor());

            var cmd = new UndoCommand();

            cmd.Execute(ctx);

            var expected = ctx.Messages["invalidsave"];

            Assert.AreEqual(expected, ctx.CurrentMessage);
        }
    }
}
