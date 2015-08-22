namespace BalloonsPops.Traversals
{
    public class BfsPopper : TraversalPopper
    {
        public BfsPopper(Board board)
            : base(board)
        {
        }
        
        protected override void PopBalloons(int row, int col, int cellValue)
        {
            if (this.board.IsValidPop(row, col) &&
                this.board[row, col].Value == cellValue)
            {
                this.board[row, col] = EmptyCell;

                PopBalloons(row - 1, col, cellValue); // Up
                PopBalloons(row + 1, col, cellValue); // Down 
                PopBalloons(row, col + 1, cellValue); // Left
                PopBalloons(row, col - 1, cellValue); // Right
            }
        }
    }
}
