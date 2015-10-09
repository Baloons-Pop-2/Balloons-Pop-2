using BalloonsPop;
using BalloonsPopConsoleApp.Commands;
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
    public class InvalidInputCommandTests
    {
        private ICommandContext ctx;
        private const string InvalidMessage = "You've messed up!";
        private readonly Dictionary<string, string> messages = new Dictionary<string, string> { { InvalidInputCommand.InvalidInputMessageKey, InvalidMessage } };

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<ICommandContext>();
            mock.SetupGet(x => x.Messages).Returns(this.messages);
            mock.SetupProperty(x => x.CurrentMessage, string.Empty);
            this.ctx = mock.Object;
        }

        [Test]
        public void OnExecuteCommandShouldSaveMessageToContext()
        {
            var command = new InvalidInputCommand();
            command.Execute(this.ctx);

            Assert.AreSame(InvalidMessage, this.ctx.CurrentMessage);
        }
    }
}
