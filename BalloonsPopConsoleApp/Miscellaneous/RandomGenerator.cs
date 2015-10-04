namespace BalloonsPopConsoleApp.Miscellaneous
{
    using System;

    public static class RandomGenerator
    {
        private static readonly Random RandomNumber = new Random();

        public static string GetRandomInt()
        {
            string legalChars = "11122233344411122253334454111222333444";
            string builder = null;
            builder = legalChars[RandomNumber.Next(0, legalChars.Length)].ToString();
            return builder;
        }
    }
}