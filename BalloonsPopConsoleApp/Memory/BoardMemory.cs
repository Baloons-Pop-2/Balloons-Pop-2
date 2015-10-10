// <copyright  file="BoardMemory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Memory
{
    using BalloonsPop;

    public class BoardMemory : IBoardMemory
    {
        public IBoardMemento Memento { get; set; }
    }
}
