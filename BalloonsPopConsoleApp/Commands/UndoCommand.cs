using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class UndoCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            if (ctx.Memory.Memento != null)
            {
                ctx.Board.RestoreMemento(ctx.Memory.Memento);   
            }
        }

        public bool CanExecute(ICommandContext ctx)
        {
            return false;
        }
    }
}
