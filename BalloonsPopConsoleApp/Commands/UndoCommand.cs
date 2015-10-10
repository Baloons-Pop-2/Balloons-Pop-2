// <copyright  file="UndoCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using BalloonsPop;
    using BalloonsPop.Commands;

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
