using BalloonsPop;
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
    public class BalloonFactoryTests
    {
        private readonly IBalloonFactory balloonFactory = new BalloonFactory();

        [Test]
        public void FactoryShouldReturnIBalloonObject()
        {
            var balloon = this.balloonFactory.GetBalloon(2);
            Assert.IsInstanceOf<IBalloon>(balloon);
        }
    }
}
