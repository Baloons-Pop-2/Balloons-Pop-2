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
            else
            {
                // Inform player that a save point is not available
                ctx.CurrentMessage = ctx.Messages["invalidsave"];
            }
        }
    }
}
