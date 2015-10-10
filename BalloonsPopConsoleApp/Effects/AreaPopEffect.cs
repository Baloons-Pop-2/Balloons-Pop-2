// <copyright  file="AreaPopEffect.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Effects
{
    using BalloonsPop;
    using Models;

    /// <summary>
    /// Traversal effect that pops a square around the balloon.
    /// </summary>
    public class AreaPopEffect : TraversalEffect
    {
        /// <summary>
        /// Overrides the abstract method for popping.
        /// </summary>
        /// <param name="row">The currently active row.</param>
        /// <param name="col">The currently active column.</param>
        /// <param name="board">The game board.</param>
        /// <param name="cellValue">The initial balloon value.</param>
        protected override void PopBalloons(int row, int col, IBoard board, int cellValue)
        {
            int upperRow = row;
            int lowerRow = row;
            int leftCol = col;
            int rightCol = col;

            if (row > 0)
            {
                upperRow--;
            }

            if (row < board.Rows - 1)
            {
                lowerRow++;
            }

            if (col > 0)
            {
                leftCol--;
            }

            if (col < board.Cols - 1)
            {
                rightCol++;
            }

            for (int currentRow = upperRow; currentRow <= lowerRow; currentRow++)
            {
                for (int currentCol = leftCol; currentCol <= rightCol; currentCol++)
                {
                    board[currentRow, currentCol] = Balloon.Default;
                }
            }
        }
    }
}
