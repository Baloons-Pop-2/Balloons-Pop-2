using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPopConsoleApp.Miscellaneous;

namespace BalloonsPopConsoleApp
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random r = new Random();

        public int GetInt(int min, int max)
        {
            return r.Next(min, max + 1);
        }
    }
}
