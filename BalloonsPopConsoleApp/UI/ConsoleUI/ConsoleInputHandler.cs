// <copyright  file="ConsoleInputHandler.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.UI.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.UI.InputHandler;

    /// <summary>
    /// IInputHandler Object that reads user input and handles any errors.
    /// </summary>
    public class ConsoleInputHandler : IInputHandler
    {
        /// <summary>
        /// List of the allowed game commands.
        /// </summary>
        protected static readonly IList<string> ValidCommands = new List<string>()
        {
            "exit",
            "restart",
            "top",
            "undo"
        };

        /// <summary>
        /// Reads input from the console and checks for null values.
        /// </summary>
        /// <returns>The trimmed string or null when the read string is empty</returns>
        public string Read()
        {
            var input = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            else
            {
                return input;
            }
        }

        /// <summary>
        /// Parses input.
        /// </summary>
        /// <param name="input">The string to be parsed.</param>
        /// <returns>Parsed string that is ready to be passed as a command. "invalidInput" is returned if the parsing fails</returns>
        public string ParseInput(string input)
        {
            if (input == null)
            {
                return "invalidInput";
            }

            var inputWords = input.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (inputWords.Length != 1 && !IsValidPopInput(input))
            {
                return "invalidInput";
            }

            if (inputWords.Length == 1 && ValidCommands.Contains(inputWords[0]))
            {
                return inputWords[0];
            }
            else if (IsValidPopInput(input))
            {
                return string.Format("pop {0} {1}", inputWords[0], inputWords[1]);
            }

            return "invalidInput";
        }

        /// <summary>
        /// checks if the input is valid.
        /// </summary>
        /// <param name="input">The input to be checked.</param>
        /// <returns>True if the input is valid, false - otherwise.</returns>
        private static bool IsValidPopInput(string input)
        {
            var splitInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (splitInput.Length == 2)
            {
                return (splitInput[0] + splitInput[1]).All(char.IsDigit);
            }

            return false;
        }
    }
}
