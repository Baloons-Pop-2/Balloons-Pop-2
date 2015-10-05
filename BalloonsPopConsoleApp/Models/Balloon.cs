namespace BalloonsPopConsoleApp.Models
{
    using System;
    using BalloonsPop;
    using BalloonsPop.Traversals;

    /// <summary>
    /// Balloon object that contains Value of type int and TraversalEffect.
    /// </summary>
    public class Balloon : IBalloon
    {
        private ITraversalEffect effect;

        /// <summary>
        /// Balloon object constructor.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="traversalEffect"></param>
        public Balloon(int value, ITraversalEffect traversalEffect)
        {
            this.Value = value;
            this.TraversalEffect = traversalEffect;
        }

        /// <summary>
        /// Default value for the Balloon object - null.
        /// </summary>
        public static Balloon Default
        {
            get { return default(Balloon); }
        }

        /// <summary>
        /// Balloon's value - used in finding the adjacent balloons of the same value
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Balloon's TraversalEffect - contains information about the pattern in which the balloon will pop when selected
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
