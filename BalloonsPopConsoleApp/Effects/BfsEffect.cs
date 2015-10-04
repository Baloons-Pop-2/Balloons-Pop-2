namespace BalloonsPopConsoleApp.Effects
{
    using Models;
    using BalloonsPop;

    public class BfsEffect : TraversalEffect
    {
        protected override void PopBalloons(int row, int col, IBoard board, int cellValue)
        {
            if (board.IsValidPop(row, col) &&
                board[row, col].Value == cellValue)
            {
                board[row, col] = Balloon.Default;

                this.PopBalloons(row - 1, col, board, cellValue); // Up
                this.PopBalloons(row + 1, col, board, cellValue); // Down 
                this.PopBalloons(row, col + 1, board, cellValue); // Left
                this.PopBalloons(row, col - 1, board, cellValue); // Right
            }
        }
    }
}
