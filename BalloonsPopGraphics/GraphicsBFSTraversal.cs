using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public class GraphicsBFSTraversal : GraphicsTraversal
    {
        protected override void PopBalloons(int row, int col, GraphicsBalloon[,] board, int cellValue, int boardSize)
        {
            if ((row >= 0 && row < boardSize && col >= 0 && col < boardSize) &&
                board[row, col].Value == cellValue && !board[row, col].IsPopped)
            {
                board[row, col].Pop();

                PopBalloons(row - 1, col, board, cellValue, boardSize); // Up
                PopBalloons(row + 1, col, board, cellValue, boardSize); // Down 
                PopBalloons(row, col + 1, board, cellValue, boardSize); // Left
                PopBalloons(row, col - 1, board, cellValue, boardSize); // Right
            }
        }
    }
}
