// <copyright file="IMemorizeable.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    /// <summary>
    /// The interface of a memorize-able object.
    /// </summary>
    /// <typeparam name="T">The type of object to be memorized.</typeparam>
    public interface IMemorizeable<T>
    {
        /// <summary>
        /// Saves the current state of the object.
        /// </summary>
        /// <returns>A clone of the object so the object can be restored.</returns>
        T SaveMemento();

        /// <summary>
        /// Restores The object to a previous state.
        /// </summary>
        /// <param name="memento">The state to which the object will be restored.</param>
        void RestoreMemento(T memento);
    }
}
