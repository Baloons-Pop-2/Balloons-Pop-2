using BalloonsPopConsoleApp.UI.ConsoleUI;
using NUnit.Framework;

namespace BalloonsPopConsoleApp.Tests.UI
{
    [TestFixture]
    public class ConsoleInputHandlerTests
    {
        [Test, Sequential]
        [Ignore]
        public void ConsoleInputHandlerReadReturnsValidTrimmedString(
            [Values(" 3 14   ", " restart", "test ")] string input,
            [Values("3 14", "restart", "test")] string expectedOutput)
        {
            //// Currently a-not-very-testable Method (Read())
        }

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
            [Values("Picasso", "rstr", "53", "Ala bala nica", "5 2 15 52")] string input,
            [Values("invalidInput", "invalidInput", "invalidInput", "invalidInput", "invalidInput")] string expectedOutput)
        {
            var inputHandler = new ConsoleInputHandler();
            Assert.AreEqual(expectedOutput, inputHandler.ParseInput(input));
        }
    }
}
