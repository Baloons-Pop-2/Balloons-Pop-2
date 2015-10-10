namespace BalloonsPopConsoleApp.Tests.UI
{
    using BalloonsPopConsoleApp.UI.ConsoleUI;
    using NUnit.Framework;

    [TestFixture]
    public class ConsoleInputHandlerTests
    {
        [Test, Sequential]
        public void ConsoleInputHandlerParseInputReturnsValidCommand(
            [Values("Restart", "top", "uNDo", "EXIT", "5 3", "0 0")] string input,
            [Values("restart", "top", "undo", "exit", "pop 5 3", "pop 0 0")] string expectedOutput)
        {
            var inputHandler = new ConsoleInputHandler();
            Assert.AreEqual(expectedOutput, inputHandler.ParseInput(input));
        }

        [Test, Sequential]
        public void ConsoleInputHandlerParseInputReturnsInvalidInputStringWhenAnInvalidStringIsPassed(
            [Values("Picasso", "rstr", "53", "Ala bala nica", "5 2 15 52", null)] string input,
            [Values("invalidInput", "invalidInput", "invalidInput", "invalidInput", "invalidInput", "invalidInput")] string expectedOutput)
        {
            var inputHandler = new ConsoleInputHandler();
            Assert.AreEqual(expectedOutput, inputHandler.ParseInput(input));
        }
    }
}
