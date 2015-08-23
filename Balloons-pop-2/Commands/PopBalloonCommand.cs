using System;

namespace BalloonsPops.Commands
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

            if (ctx.ActiveRow == null || ctx.ActiveCol == null)
            {
                throw new ArgumentNullException("active cell");
            }
            this.activeRow = (int)ctx.ActiveRow;
            this.activeCol = (int)ctx.ActiveCol;

            Pop(this.activeRow, this.activeCol);
        }
    }
}
