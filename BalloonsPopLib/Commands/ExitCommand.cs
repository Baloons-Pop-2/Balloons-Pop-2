using System;

namespace BalloonsPop.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute(CommandContext ctx)
        {
            Environment.Exit(42);
        }
    }
}
