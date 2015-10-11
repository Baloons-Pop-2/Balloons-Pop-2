using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public static class RandomGenerator
    {
        static Random random = new Random();

        public static int GetRandomInt()
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
