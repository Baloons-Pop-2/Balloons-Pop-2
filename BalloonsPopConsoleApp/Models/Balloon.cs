// <copyright  file="Balloon.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Models
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Traversals;

    /// <summary>
    /// Balloon object that contains integer value and TraversalEffect.
    /// </summary>
    public class Balloon : IBalloon
    {
        private ITraversalEffect effect;

        /// <summary>
        /// Balloon object constructor.
        /// </summary>
        /// <param name="value">The value of the balloon.</param>
        /// <param name="traversalEffect">The traversal strategy to interact with adjacent balloons.</param>
        public Balloon(int value, ITraversalEffect traversalEffect)
        {
            this.Value = value;
            this.TraversalEffect = traversalEffect;
        }

        /// <summary>
        /// Gets the Default value for the Balloon object - null.
        /// </summary>
        public static Balloon Default
        {
            get { return default(Balloon); }
        }

        /// <summary>
        /// Gets the integer value of the balloon.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Gets the traversal popping effect.
        /// </summary>
        public ITraversalEffect TraversalEffect
        {
            get
            {
                return this.effect;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("effect");
                }

                this.effect = value;
            }
        }
    }
}
