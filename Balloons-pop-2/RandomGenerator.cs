﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public static class RandomGenerator
    {

        static Random randomNumber = new Random();
        public static string GetRandomInt()
        {
            string legalChars = "1234";
            string builder = null;
            builder = legalChars[randomNumber.Next(0, legalChars.Length)].ToString();
            return builder;
        }
    }
}