// <copyright file="IPicasso.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPop.UI.Drawer
{
    /// <summary>
    /// The interface of the drawer.
    /// </summary>
    public interface IPicasso
    {
        /// <summary>
        /// Draws an object somewhere.
        /// </summary>
        /// <param name="obj">The object to be drawn.</param>
        void Draw(object obj);

        /// <summary>
        /// Clears all the previously drawn objects.
        /// </summary>
        void Clear();
    }
}
