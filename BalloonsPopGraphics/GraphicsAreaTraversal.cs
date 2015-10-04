using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public class GraphicsAreaTraversal : GraphicsTraversal
    {
        protected override void PopBalloons(int row, int col, GraphicsBalloon[,] board, int cellValue, int boardSize)
        {

            int upperRow = row;
            int lowerRow = row;
            int leftCol = col;
            int rightCol = col;

            if (row > 0) upperRow--;
            if (row < boardSize - 1) lowerRow++;
            if (col > 0) leftCol--;
            if (col < boardSize - 1) rightCol++;

            for (int currentRow = upperRow; currentRow <= lowerRow; currentRow++)
            {
                for (int currentCol = leftCol; currentCol <= rightCol; currentCol++)
                {
                    board[currentRow, currentCol].Pop();
                }
            }
        }
    }
}
