using BalloonsPop;
using BalloonsPopConsoleApp.Effects;
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

        [Test]
        public void FactoryShouldReturnBalloonWithRightValue()
        {
            Assert.AreEqual(2, this.balloonFactory.GetBalloon(2).Value);
            Assert.AreEqual(4, this.balloonFactory.GetBalloon(4).Value);
            Assert.AreEqual(5, this.balloonFactory.GetBalloon(5).Value);
        }

        [Test]
        public void FactoryShouldCreateBalloonWithCorrectEffect()
        {
            Assert.IsInstanceOf<AreaPopEffect>(this.balloonFactory.GetBalloon(5).TraversalEffect);
            Assert.IsInstanceOf<BfsEffect>(this.balloonFactory.GetBalloon(1).TraversalEffect);
            Assert.IsInstanceOf<BfsEffect>(this.balloonFactory.GetBalloon(3).TraversalEffect);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void FactoryShouldThrowExceptionWhenInvalidValuePassed()
        {
            var balloon = this.balloonFactory.GetBalloon(8);
        }
    }
}
