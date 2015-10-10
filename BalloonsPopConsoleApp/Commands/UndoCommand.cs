// <copyright  file="UndoCommand.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Commands
{
    using BalloonsPop;
    using BalloonsPop.Commands;

    /// <summary>
    /// A concrete ICommand Implementation that restores an object to its previous stable state.
    /// </summary>
    public class UndoCommand : ICommand
    {
        /// <summary>
        /// Executes the Undo Command on the passed context.
        /// </summary>
        /// <param name="ctx">the context that contains a Memento object</param>
        public void Execute(ICommandContext ctx)
        {
            if (ctx.Memory.Memento != null)
            {
                ctx.Board.RestoreMemento(ctx.Memory.Memento);
            }
            else
            {
                // Inform the player that a save point is not available
                ctx.CurrentMessage = ctx.Messages["invalidsave"];
            }
        }
    }
}
