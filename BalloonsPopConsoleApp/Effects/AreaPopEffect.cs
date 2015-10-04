namespace BalloonsPopConsoleApp.Effects
{
    using Models;
    using BalloonsPop;

    public class AreaPopEffect : TraversalEffect
    {
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
