// <copyright  file="ExitCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using BalloonsPop;
    using BalloonsPop.Commands;

    public class ExitCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            ctx.IsOver = true;
        }
    }
}
