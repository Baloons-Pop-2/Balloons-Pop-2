namespace BalloonsPopConsoleApp.Effects
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Traversals;
    using Models;

    public abstract class TraversalEffect : ITraversalEffect
    {
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

        protected abstract void PopBalloons(int row, int col, IBoard board, int cellValue);

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
