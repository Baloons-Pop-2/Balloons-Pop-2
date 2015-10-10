// <copyright  file="PopBalloonsCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Commands;

    public class PopBalloonCommand : ICommand
    {
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

            this.Pop(ctx.Board, ctx.ActiveRow, ctx.ActiveCol);
            ctx.CurrentMessage = string.Empty;
        }

        private void Pop(IBoard board, int row, int col)
        {
            var balloon = board[row, col];
            var traversal = balloon.TraversalEffect;
            traversal.Pop(row, col, board);
        }
    }
}
