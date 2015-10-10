// <copyright  file="RandomGenerator.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System;

    /// <summary>
    /// Represents a Random object that returns semi-random values on demand
    /// </summary>
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random r = new Random();

        /// <summary>
        /// Gets a random value in the specified range
        /// </summary>
        /// <param name="min">beginning of the random range</param>
        /// <param name="max">end of the random range</param>
        /// <returns>Random value in the range between "min" and "max"</returns>
        public int GetInt(int min, int max)
        {
            return this.r.Next(min, max + 1);
        }
    }
}
