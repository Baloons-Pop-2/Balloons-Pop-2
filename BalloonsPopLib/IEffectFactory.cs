// <copyright file="IEffectFactory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    using Traversals;

    /// <summary>
    /// The interface of the effect factory.
    /// </summary>
    public interface IEffectFactory
    {
        /// <summary>
        /// Creates the default traversal effect for the balloons.
        /// </summary>
        /// <returns>An object that implements ITraversalEffect.</returns>
        ITraversalEffect GetDefaultEffect();

        /// <summary>
        /// Creates the special traversal effect for the balloons.
        /// </summary>
        /// <returns>An object that implements ITraversalEffect.</returns>
        ITraversalEffect GetAreaPopEffect();
    }
}
