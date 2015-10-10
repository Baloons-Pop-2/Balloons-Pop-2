// <copyright file="IBalloon.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    using Traversals;

    /// <summary>
    /// The interface of the balloons.
    /// </summary>
    public interface IBalloon
    {
        /// <summary>
        /// Gets integer value of the balloon.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// Gets the way that the balloon pops.
        /// </summary>
        ITraversalEffect TraversalEffect { get; }
    }
}
