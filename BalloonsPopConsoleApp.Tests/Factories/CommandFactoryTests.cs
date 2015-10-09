using BalloonsPop;
using BalloonsPopConsoleApp.Commands;
using BalloonsPopConsoleApp.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopConsoleApp.Tests.Factories
{
    [TestFixture]
    public class CommandFactoryTests
    {
        private readonly ICommandFactory commandFactory = new CommandFactory();

        [Test]
        public void ShouldReturnCorrectCommandWhenPopParameterPassed()
        {
            var command = this.commandFactory.GetCommand("pop");
            Assert.IsInstanceOf<PopBalloonCommand>(command);
        }

        [Test]
        public void ShouldReturnCorrectCommandWhenExitParameterPassed()
        {
            var command = this.commandFactory.GetCommand("exit");
            Assert.IsInstanceOf<ExitCommand>(command);
        }

        [Test]
        public void ShouldReturnCorrectCommandWhenInvalidInputParameterPassed()
        {
            var command = this.commandFactory.GetCommand("invalidinput");
            Assert.IsInstanceOf<InvalidInputCommand>(command);
        }

        [Test]
        public void ShouldReturnCorrectCommandWhenRestartParameterPassed()
        {
            var command = this.commandFactory.GetCommand("restart");
            Assert.IsInstanceOf<RestartCommand>(command);
        }

        [Test]
        public void ShouldReturnCorrectCommandWhenUndoParameterPassed()
        {
            var command = this.commandFactory.GetCommand("undo");
            Assert.IsInstanceOf<UndoCommand>(command);
        }

        [Test]
        public void ShouldReturnCorrectCommandWhenTopParameterPassed()
        {
            var command = this.commandFactory.GetCommand("top");
            Assert.IsInstanceOf<ShowTopScoreCommand>(command);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenInvalidCommandPassed()
        {
            var command = this.commandFactory.GetCommand("break");
        }
    }
}
