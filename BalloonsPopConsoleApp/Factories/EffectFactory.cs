// <copyright  file="EffectFactory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Factories
{
    using BalloonsPop;
    using BalloonsPop.Traversals;
    using Effects;

    /// <summary>
    /// The factory for the balloon's effects.
    /// </summary>
    public class EffectFactory : IEffectFactory
    {
        /// <summary>
        /// Gets the default traversal effect.
        /// </summary>
        /// <returns>An object that implements the ITraversalPattern interface.</returns>
        public ITraversalEffect GetDefaultEffect()
        {
            return new BfsEffect();
        }

        /// <summary>
        /// Gets a special traversal effect.
        /// </summary>
        /// <returns>An object that implements the ITraversalPattern interface.</returns>
        public ITraversalEffect GetAreaPopEffect()
        {
            return new AreaPopEffect();
        }
    }
}
