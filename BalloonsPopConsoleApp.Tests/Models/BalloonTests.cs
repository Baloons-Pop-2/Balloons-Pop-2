using System;
using BalloonsPopConsoleApp.Effects;
using BalloonsPopConsoleApp.Models;
using NUnit.Framework;

namespace BalloonsPopConsoleApp.Tests.Models
{
	[TestFixture]
    public class BalloonTests
    {
	    [Test]
        public void BalloonWithProperValueAndValidTraversalShouldBeCreated(
            [Values(1, 2, 3, 4, 5)] int validValue)
	    {
	        var balloon = new Balloon(validValue, new AreaPopEffect());
	    }

	    [Test]
        [ExpectedException(typeof(ArgumentNullException))]
	    public void BalloonWithProperValueAndInvalidTraversalShouldThrow()
	    {
	        var balloon = new Balloon(2, null);
	    }

	    [Test]
	    public void BalloonTraversalEffectReturnsAppropriateEffect()
	    {
	        var balloon = new Balloon(2, new BfsEffect());
	        var effect = balloon.TraversalEffect;
	        var effType = effect.GetType();

            Assert.IsTrue(typeof(BfsEffect) == effType);
	    }
    }
}
