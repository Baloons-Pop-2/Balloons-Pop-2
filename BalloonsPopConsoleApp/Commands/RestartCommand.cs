// <copyright  file="RestartCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Commands;

    /// <summary>
    /// A concrete ICommand Implementation that resets the board object and player's moves
    /// </summary>
    public class RestartCommand : ICommand
    {
        /// <summary>
        /// The initial key of a Dictionary in the context object.
        /// </summary>
        public const string WelcomeMessageKey = "welcome";

        /// <summary>
        /// Executes the Restart Command on the passed context.
        /// </summary>
        /// <param name="ctx">The context that contains the board object.</param>
        public void Execute(ICommandContext ctx)
        {
            ctx.Board.Reset();
            ctx.Score.SetMoves(0);
            ctx.CurrentMessage = ctx.Messages[WelcomeMessageKey];

            ctx.Logger.Log(string.Format("Started new game at: {0}", DateTime.Now));
        }
    }
}
