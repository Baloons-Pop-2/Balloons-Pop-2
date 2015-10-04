using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BalloonsPopGraphics
{
    public abstract class GraphicsTraversal
    {
        public void Pop(int row, int col, GraphicsBalloon[,] board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }
            PopBalloons(row, col, board, board[row, col].Value, 8);

            ClearEmptyCells(board);
        }

        protected abstract void PopBalloons(int row, int col, GraphicsBalloon[,] board, int cellValue, int boardSize);

        private void ClearEmptyCells(GraphicsBalloon[,] board)
        {
            int row;
            int col;

            Queue<GraphicsBalloon> baloonsToPop = new Queue<GraphicsBalloon>();
            for (col = 7; col >= 0; col--)
            {
                for (row = 7; row >= 0; row--)
                {
                    if (!board[row, col].IsPopped)
                    {
                        baloonsToPop.Enqueue(board[row, col]);
                        board[row, col].Pop();
                    }
                }

                row = 7;
                while (baloonsToPop.Count > 0)
                {
                    board[row, col] = baloonsToPop.Dequeue();
                    board[row, col].Unpop();
                    Grid.SetRow(board[row, col], row);
                    Grid.SetColumn(board[row, col], col);
                    row--;
                }

                baloonsToPop.Clear();
            }
        }
    }
}
