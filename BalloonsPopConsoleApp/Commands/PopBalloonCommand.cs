// <copyright  file="PopBalloonCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Commands;

    /// <summary>
    /// A concrete ICommand Implementation that interacts with objects passed in the context.
    /// </summary>
    public class PopBalloonCommand : ICommand
    {
        /// <summary>
        /// Executes the PopBalloon Command on a balloon passed in the context.
        /// </summary>
        /// <param name="ctx">the context that contains the row, column, and board object on which the command is executed.</param>
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

        /// <summary>
        /// Executes the traversal strategy on a target balloon with the provided row and column in the board object.
        /// </summary>
        /// <param name="board">The board object.</param>
        /// <param name="row">Target row of the balloon.</param>
        /// <param name="col">Target column of the balloon.</param>
        private void Pop(IBoard board, int row, int col)
        {
            var balloon = board[row, col];
            var traversal = balloon.TraversalEffect;
            traversal.Pop(row, col, board);
        }
    }
}
