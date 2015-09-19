using BalloonsPop;

namespace BalloonsPopConsoleApp.Effects
{
    public class BfsEffect : TraversalEffect
    {
        protected override void PopBalloons(int row, int col, IBoard board, int cellValue)
        {
            if (board.IsValidPop(row, col) &&
                board[row, col].Value == cellValue)
            {
                board[row, col] = Balloon.Default;

                PopBalloons(row - 1, col, board, cellValue); // Up
                PopBalloons(row + 1, col, board, cellValue); // Down 
                PopBalloons(row, col + 1, board, cellValue); // Left
                PopBalloons(row, col - 1, board, cellValue); // Right
            }
        }
    }
}
