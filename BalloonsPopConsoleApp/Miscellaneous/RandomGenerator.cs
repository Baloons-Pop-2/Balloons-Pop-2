// <copyright  file="RandomGenerator.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System;

    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random r = new Random();

        public int GetInt(int min, int max)
        {
            return this.r.Next(min, max + 1);
        }
    }
}
