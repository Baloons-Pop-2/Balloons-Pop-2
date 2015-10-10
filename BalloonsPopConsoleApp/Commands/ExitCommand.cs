// <copyright  file="ExitCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using BalloonsPop;
    using BalloonsPop.Commands;

    /// <summary>
    /// A concrete implementation of the ICommand interface for exiting the game.
    /// </summary>
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// Sets the IsOver property of the context to true to indicate the end of the game.
        /// </summary>
        /// <param name="ctx">The game context.</param>
        public void Execute(ICommandContext ctx)
        {
            ctx.IsOver = true;
        }
    }
}
