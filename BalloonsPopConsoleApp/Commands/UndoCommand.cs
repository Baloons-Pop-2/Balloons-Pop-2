using BalloonsPop;
using BalloonsPop.Commands;

namespace BalloonsPopConsoleApp.Commands
{
    public class UndoCommand : ICommand
    {
        public void Execute(ICommandContext ctx)
        {
            ctx.Board.RestoreMemento(ctx.Memory.Memento);
        }
    }
}
