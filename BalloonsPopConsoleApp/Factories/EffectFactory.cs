// <copyright  file="EffectFactory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Factories
{
    using BalloonsPop;
    using BalloonsPop.Traversals;
    using Effects;

    public class EffectFactory : IEffectFactory
    {
        public ITraversalEffect GetDefaultEffect()
        {
            return new BfsEffect();
        }

        public ITraversalEffect GetAreaPopEffect()
        {
            return new AreaPopEffect();
        }
    }
}
