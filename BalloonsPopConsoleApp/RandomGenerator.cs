using System;

namespace BalloonsPopConsoleApp
{
    public static class RandomGenerator
    {

        static Random randomNumber = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "11122233344411122253334454111222333444";
            string builder = null;
            builder = legalChars[randomNumber.Next(0, legalChars.Length)].ToString();
            return builder;
        }
    }
}