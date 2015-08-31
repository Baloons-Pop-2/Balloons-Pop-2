using System;

namespace BalloonsPop.Commands
{
    public class PopBalloonCommand : ICommand
    {
        private IBoard board;
        private int activeRow;
        private int activeCol;

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

        public void Execute(CommandContext ctx)
        {
            if (ctx.Board == null)
            {
                throw new ArgumentNullException("board");
            }
            this.board = ctx.Board;

            this.activeRow = ctx.ActiveRow;
            this.activeCol = ctx.ActiveCol;

            Pop(this.activeRow, this.activeCol);
        }
    }
}
