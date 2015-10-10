// <copyright  file="InvalidInputCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using BalloonsPop;
    using BalloonsPop.Commands;

    public class InvalidInputCommand : ICommand
    {
        public const string InvalidInputMessageKey = "invalidcommand";

        public void Execute(ICommandContext ctx)
        {
            // inform player that the input is not valid
            ctx.CurrentMessage = ctx.Messages[InvalidInputMessageKey];
        }
    }
}
