using System;
using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            Environment.Exit(42);
        }

        public bool CanExecute(ICommandContext ctx)
        {
            return false;
        }
    }
}
