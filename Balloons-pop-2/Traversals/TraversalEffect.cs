using System;
using System.Collections.Generic;

namespace BalloonsPops.Traversals
{
    public abstract class TraversalEffect : ITraversalEffect
    {
        public void Pop(int row, int col, IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            var balloon = board[row, col];

            PopBalloons(row, col, board, balloon.Value);

            ClearEmptyCells(board);
        }

        protected abstract void PopBalloons(int row, int col, IBoard board, int cellValue);

        private void ClearEmptyCells(IBoard board)
        {
            int row;
            int col;

            Queue<Balloon> baloonsToPop = new Queue<Balloon>();
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
