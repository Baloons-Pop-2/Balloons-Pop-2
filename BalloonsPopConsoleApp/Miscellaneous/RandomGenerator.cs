// <copyright  file="RandomGenerator.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents a Random object that returns semi-random values on demand
    /// </summary>
    public class RandomGenerator : IRandomGenerator
    {
        /// <summary>
        /// The instance of the Random class which returns semi-random values
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Gets a random value in the specified range
        /// </summary>
        /// <param name="min">beginning of the randьom range</param>
        /// <param name="max">end of the random range</param>
        /// <returns>Random value in the range between "min" and "max"</returns>
        public int GetInt(int min, int max)
        {
            var probabilities = new[] { 35, 35, 35, 35, 10 };
            var probabilitiesSum = probabilities.Sum();
            int tempRand = random.Next(0, probabilitiesSum);
            var currentSum = 0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                currentSum += probabilities[i];
                if (tempRand < currentSum)
                {
                    return (i + 1);
                }
            }

            throw new InvalidOperationException();
        }
    }
}
