// <copyright  file="TraversalEffect.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Effects
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Traversals;
    using Models;

    /// <summary>
    /// The class defines the way a an object from the board will interact with other objects.
    /// </summary>
    public abstract class TraversalEffect : ITraversalEffect
    {
        /// <summary>
        /// Pops the balloons on the board according to their traversal effect.
        /// </summary>
        /// <param name="row">The row on which is the balloon.</param>
        /// <param name="col">The column on which is the balloon.</param>
        /// <param name="board">The board object of the game.</param>
        public void Pop(int row, int col, IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            var balloon = board[row, col];

            this.PopBalloons(row, col, board, balloon.Value);

            this.ClearEmptyCells(board);
        }

        /// <summary>
        /// Pops the balloons on the board according to their traversal effect.
        /// </summary>
        /// <param name="row">The row on which is the balloon.</param>
        /// <param name="col">The column on which is the balloon.</param>
        /// <param name="board">The board object of the game.</param>
        /// <param name="cellValue">The integer value of the object on the specified row and column.</param>
        protected abstract void PopBalloons(int row, int col, IBoard board, int cellValue);

        /// <summary>
        /// Clears all empty cells and moves all balloons on the column to rows greater than their current one if there are vacant indexes.
        /// </summary>
        /// <param name="board">The board object of the game.</param>
        private void ClearEmptyCells(IBoard board)
        {
            int row;
            int col;

            Queue<IBalloon> baloonsToPop = new Queue<IBalloon>();
            for (col = board.Cols - 1; col >= 0; col--)
            {
                for (row = board.Rows - 1; row >= 0; row--)
                {
                    if (board[row, col] != Balloon.Default)
                    {
                        baloonsToPop.Enqueue(board[row, col]);
                        board[row, col] = Balloon.Default;
                    }
                }

                row = board.Rows - 1;
                while (baloonsToPop.Count > 0)
                {
                    board[row, col] = baloonsToPop.Dequeue();
                    row--;
                }

                baloonsToPop.Clear();
            }
        }
    }
}
