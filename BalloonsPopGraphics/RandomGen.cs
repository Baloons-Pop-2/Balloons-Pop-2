using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPopGraphics
{
    public static class RandomGenerator
    {
        static Random randomNumber = new Random();

        public static int GetRandomInt()
        {
            string legalChars = "11122233344411122253334454111222333444";
            string builder = null;
            builder = legalChars[randomNumber.Next(0, legalChars.Length)].ToString();
            return int.Parse(builder);
        }
    }
}
