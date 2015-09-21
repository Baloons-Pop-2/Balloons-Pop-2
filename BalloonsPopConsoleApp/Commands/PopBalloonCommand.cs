using System;
using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
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
                return;
            }

            var balloon = this.board[row, col];
            var traversal = balloon.TraversalEffect;
            traversal.Pop(row, col, this.board);
        }

        public void Execute(ICommandContext ctx)
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
