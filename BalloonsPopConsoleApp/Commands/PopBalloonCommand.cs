using System;
using System.Runtime.InteropServices.ComTypes;
using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class PopBalloonCommand : ICommand
    {
        private void Pop(IBoard board, int row, int col)
        {
            var balloon = board[row, col];
            var traversal = balloon.TraversalEffect;
            traversal.Pop(row, col, board);
        }

        public void Execute(ICommandContext ctx)
        {
            if (ctx.Board == null)
            {
                throw new ArgumentNullException("board");
            }

            if (!ctx.Board.IsValidPop(ctx.ActiveRow, ctx.ActiveCol))
            {
                ctx.CurrentMessage = ctx.Messages["invalidmove"];
                return;
            }

            Pop(ctx.Board, ctx.ActiveRow, ctx.ActiveCol);
            ctx.CurrentMessage = "";
        }
    }
}
