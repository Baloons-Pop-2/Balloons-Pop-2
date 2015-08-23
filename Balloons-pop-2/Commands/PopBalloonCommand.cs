using System;

namespace BalloonsPops.Commands
{
    public class PopBalloonCommand : ICommand
    {
        private IBoard board;

        public PopBalloonCommand(IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board");
            }

            this.board = board;
        }

        private void Pop(int row, int col)
        {
            if (!this.board.IsValidPop(row, col))
            {
                throw new IndexOutOfRangeException("out of the board");
            }

            var balloon = this.board[row, col];
            var traversal = balloon.TraversalEffect;
            traversal.Pop(row, col, this.board);
        }

        public void Execute()
        {
             
        }
    }
}
