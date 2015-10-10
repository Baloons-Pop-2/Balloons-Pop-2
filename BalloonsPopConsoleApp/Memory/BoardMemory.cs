// <copyright  file="BoardMemory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Memory
{
    using BalloonsPop;

    /// <summary>
    /// The memento object director.
    /// </summary>
    public class BoardMemory : IBoardMemory
    {
        /// <summary>
        /// Gets or sets the memento object that saves a concrete state of the Board.
        /// </summary>
        public IBoardMemento Memento { get; set; }
    }
}
