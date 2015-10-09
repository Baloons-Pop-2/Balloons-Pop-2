namespace BalloonsPopConsoleApp.Commands
{
    using System;
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
