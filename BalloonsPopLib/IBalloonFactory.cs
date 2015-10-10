// <copyright  file="IBalloonFactory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop
{
    /// <summary>
    /// The interface of the balloon factory.
    /// </summary>
    public interface IBalloonFactory
    {
        /// <summary>
        /// Factory method for creating balloons based on an integer value.
        /// </summary>
        /// <param name="value">The integer on which depends the balloon type.</param>
        /// <returns>An object which implements IBalloon</returns>
        IBalloon GetBalloon(int value);
    }
}
