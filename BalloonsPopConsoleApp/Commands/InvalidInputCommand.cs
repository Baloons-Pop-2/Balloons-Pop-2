// <copyright  file="InvalidInputCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using BalloonsPop;
    using BalloonsPop.Commands;

    /// <summary>
    /// A concrete ICommand Implementation that informs the player of invalid input or actions.
    /// </summary>
    public class InvalidInputCommand : ICommand
    {
        /// <summary>
        /// The key of a Dictionary in the context object.
        /// </summary>
        public const string InvalidInputMessageKey = "invalidcommand";

        /// <summary>
        /// Executes the InvalidInput Command on the passed context, informing the player of occurring illegal input.
        /// </summary>
        /// <param name="ctx">The context of the game.</param>
        public void Execute(ICommandContext ctx)
        {
            // inform player that the input is not valid
            ctx.CurrentMessage = ctx.Messages[InvalidInputMessageKey];
        }
    }
}
