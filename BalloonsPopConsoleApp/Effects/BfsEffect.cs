// <copyright  file="BfsEffect.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Effects
{
    using BalloonsPop;
    using Models;

    /// <summary>
    /// Traversal effect that pops the balloons via BFS.
    /// </summary>
    public class BfsEffect : TraversalEffect
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
            if (board.IsValidPop(row, col) &&
                board[row, col].Value == cellValue)
            {
                board[row, col] = Balloon.Default;

                this.PopBalloons(row - 1, col, board, cellValue); // Up
                this.PopBalloons(row + 1, col, board, cellValue); // Down 
                this.PopBalloons(row, col + 1, board, cellValue); // Left
                this.PopBalloons(row, col - 1, board, cellValue); // Right
            }
        }
    }
}
