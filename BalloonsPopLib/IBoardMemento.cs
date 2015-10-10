// <copyright file="IBoardMemento.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    /// <summary>
    /// The interface of the board Memento.
    /// </summary>
    public interface IBoardMemento
    {
        /// <summary>
        /// Gets the IBalloon array that represents a concrete state of the game.
        /// </summary>
        IBalloon[,] Board { get; }
    }
}
