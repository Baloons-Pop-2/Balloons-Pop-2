namespace BalloonsPopConsoleApp.Tests.UI
{
    using BalloonsPopConsoleApp.UI.ConsoleUI;
    using NUnit.Framework;

    [TestFixture]
    public class ConsoleUserInterfaceTests
    {
        [Test]
        public void ConsoleUserInterfaceShouldContainValidReaderAndDrawerObjects()
        {
            var ui = new ConsoleUserInterface();

            Assert.IsTrue(ui.Drawer != null &&
                ui.Reader != null);
        }
    }
}
