// <copyright file="IBoardMemory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    /// <summary>
    /// The interface of the board memento director.
    /// </summary>
    public interface IBoardMemory
    {
        /// <summary>
        /// Gets or sets the memento for the balloon board, so an UNDO command can be executed.
        /// </summary>
        IBoardMemento Memento { get; set; }
    }
}
