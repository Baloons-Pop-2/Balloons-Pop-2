using BalloonsPop;
using BalloonsPop.Traversals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BalloonsPopGraphics
{
    public class Effect
    {
        public void Pop(int row, int col, test[,] board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }
            PopBalloons(row, col, board, board[row, col].Value);

            ClearEmptyCells(board);
        }

        void PopBalloons(int row, int col, test[,] board, int cellValue)
        {
            if ((row >=0 &&row < 8 && col >=0 && col < 8) &&
                board[row, col].Value == cellValue && !board[row, col].IsPopped)
            {
                board[row, col].Pop();

                PopBalloons(row - 1, col, board, cellValue); // Up
                PopBalloons(row + 1, col, board, cellValue); // Down 
                PopBalloons(row, col + 1, board, cellValue); // Left
                PopBalloons(row, col - 1, board, cellValue); // Right
            }
        }

        private void ClearEmptyCells(test[,] board)
        {
            int row;
            int col;

            Queue<test> baloonsToPop = new Queue<test>();
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
                    board[row,col].Unpop();
                    Grid.SetRow(board[row, col], row);
                    Grid.SetColumn(board[row, col], col);
                    row--;
                }

                baloonsToPop.Clear();
            }
        }
    }
}
