using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPops.Traversals
{
    public abstract class TraversalPopper : ITraversalPopper
    {
        protected const Balloon EmptyCell = null;
        protected Board board;
        

        protected TraversalPopper(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            this.board = board;
        }

        public void Pop(int row, int col)
        {
            var balloon = this.board[row, col];

            PopBalloons(row, col, balloon.Value);

            ClearEmptyCells();
        }

        protected abstract void PopBalloons(int row, int col, int cellValue);

        private void ClearEmptyCells()
        {
            int row;
            int col;

            Queue<Balloon> baloonsToPop = new Queue<Balloon>();
            for (col = this.board.Cols - 1; col >= 0; col--)
            {
                for (row = this.board.Rows - 1; row >= 0; row--)
                {
                    if (this.board[row, col] != EmptyCell)
                    {
                        baloonsToPop.Enqueue(this.board[row, col]);
                        this.board[row, col] = EmptyCell;
                    }
                }

                row = this.board.Rows - 1;
                while (baloonsToPop.Count > 0)
                {
                    this.board[row, col] = baloonsToPop.Dequeue();
                    row--;
                }

                baloonsToPop.Clear();
            }
        }
    }
}
