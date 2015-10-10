using BalloonsPopConsoleApp.Effects;
using BalloonsPopConsoleApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPopConsoleApp.Miscellaneous;

namespace BalloonsPopConsoleApp.Tests.Effects
{
    [TestFixture]
    public class BfsEffectTests
    {
        [Test]
        public void BfsEffectShouldPopAtLeastOneBalloon()
        {
            var effect = new BfsEffect();
            var board = new Board(8, 8, new RandomGenerator());
            effect.Pop(4, 4, board);

            var hasPoppedBalloon = false;

            for (int col = 0; col < 8; col++)
            {
                if (board[0, col] == Balloon.Default)
                {
                    hasPoppedBalloon = true;
                    break;
                }
            }

            Assert.IsTrue(hasPoppedBalloon);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenNullBoardPassed()
        {
            var effect = new BfsEffect();
            effect.Pop(0, 0, null);
        }
    }
}
