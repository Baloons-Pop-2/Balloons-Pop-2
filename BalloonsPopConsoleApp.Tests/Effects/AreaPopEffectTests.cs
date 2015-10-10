using BalloonsPopConsoleApp.Effects;
using BalloonsPopConsoleApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopConsoleApp.Tests.Effects
{
     [TestFixture]
    public class AreaPopEffectTests
    {
         [Test]
         public void AreaPopShouldPopCorrectlyOnCorner()
         {
             var effect = new AreaPopEffect();
             var board = new Board(8, 8, new RandomGenerator());
             effect.Pop(0, 0, board);

             for (int row = 0; row < 8; row++)
             {
                 for (int col = 0; col < 8; col++)
                 {
                     if (row < 2 && col < 2)
                     {
                         if (board[row, col] != Balloon.Default)
                         {
                             Assert.Fail("Balloons didn't pop.");
                         }
                     }
                     else
                     {
                         if (board[row, col] == Balloon.Default)
                         {
                             Assert.Fail("Too many balloons popped.");
                         }
                     }
                 }
             }
         }

         [Test]
         public void AreaPopShouldPopCorrectlyOnCenter()
         {
             var effect = new AreaPopEffect();
             var board = new Board(8, 8, new RandomGenerator());
             effect.Pop(4, 4, board);

             for (int row = 0; row < 8; row++)
             {
                 for (int col = 0; col < 8; col++)
                 {
                     if (row < 3 && col >2 && col < 6)
                     {
                         if (board[row, col] != Balloon.Default)
                         {
                             Assert.Fail("Balloons didn't pop.");
                         }
                     }
                     else
                     {
                         if (board[row, col] == Balloon.Default)
                         {
                             Assert.Fail("Too many balloons popped.");
                         }
                     }
                 }
             }
         }
    }
}
