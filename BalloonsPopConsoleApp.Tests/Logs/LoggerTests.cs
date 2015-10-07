using BalloonsPop.Logs;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopConsoleApp.Tests.Logs
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void ShouldLogCorrectly()
        {
            var mock = new Mock<ILogger>();
            var result = string.Empty;
            mock.Setup(l => l.Log("MESSAGE"))
                .Callback<string>((s) => { result = s; });

            mock.Object.Log("MESSAGE");

            Assert.AreEqual("MESSAGE", result);
            mock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }
    }
}
