namespace BalloonsPopConsoleApp.Tests.Miscellaneous
{
    using Factories;
    using Memory;
    using BalloonsPopConsoleApp.Miscellaneous;
    using BalloonsPopConsoleApp.Models;
    using BalloonsPopConsoleApp.UI.ConsoleUI;
    using NUnit.Framework;
    using BalloonsPopConsoleApp.Logs;
    using BalloonsPopConsoleApp.Factories;

    [TestFixture]
    public class GameEngineDependenciesTests
    {
        private GameEngineDependencies dependencies;

        [TestFixtureSetUp]
        public void SetUpObject()
        {
            this.dependencies = new GameEngineDependencies(new ConsoleUserInterface(), new Logger(), new Board(5, 5), new BoardMemory(), new CommandFactory());
        }

        [TestFixtureTearDown]
        public void DestroyObject()
        {
            this.dependencies = null;
        }

        [Test]
        public void GameEngineDependenciesShouldCreateProperly()
        {
            Assert.IsTrue(this.dependencies != null);
        }

        [Test]
        public void GameEngineDependenciesPropertiesAreValidAndAccessible()
        {
            Assert.IsTrue(this.dependencies.UserInterface != null && 
                this.dependencies.Logger != null && 
                this.dependencies.Board != null && 
                this.dependencies.BoardMemory != null && 
                this.dependencies.CommandFactory != null);
        }
    }
}
