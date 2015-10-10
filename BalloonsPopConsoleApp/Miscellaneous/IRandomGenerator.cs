// <copyright  file="IRandomGenerator.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    /// <summary>
    /// The interface of a random generator.
    /// </summary>
    public interface IRandomGenerator
    {
        /// <summary>
        /// Gets a random value in the specified range
        /// </summary>
        /// <param name="min">beginning of the random range</param>
        /// <param name="max">end of the random range</param>
        /// <returns>Random value in the range between "min" and "max"</returns>
        int GetInt(int min, int max);
    }
}
