﻿// <copyright  file="CommandFactory.cs" company="dentia.Pip3r4o">
// All rights reserved.
// </copyright>
// <author>dentia, Pip3r4o</author>

namespace BalloonsPopConsoleApp.Factories
{
    using System;
    using System.Collections.Generic;
    using BalloonsPop;
    using BalloonsPop.Commands;
    using Commands;

    /// <summary>
    /// The factory for the game commands.
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        /// <summary>
        /// The dictionary that holds the already created commands.
        /// </summary>
        private readonly Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();

        /// <summary>
        /// Gets the wanted command based on the input.
        /// </summary>
        /// <param name="command">The concrete command name.</param>
        /// <returns>An object which implements the ICommand interface.</returns>
        public ICommand GetCommand(string command)
        {
            command = command.ToLower();
            if (this.commandDictionary.ContainsKey(command))
            {
                return this.commandDictionary[command];
            }
            else
            {
                ICommand newCommand;

                switch (command)
                {
                    case "pop":
                        newCommand = new PopBalloonCommand();
                        break;
                    case "exit":
                        newCommand = new ExitCommand();
                        break;
                    case "restart":
                        newCommand = new RestartCommand();
                        break;
                    case "top":
                        newCommand = new ShowTopScoreCommand();
                        break;
                    case "undo":
                        newCommand = new UndoCommand();
                        break;
                    case "invalidinput":
                        newCommand = new InvalidInputCommand();
                        break;
                    default:
                        throw new ArgumentException("Invalid command " + command.ToLower());
                }

                this.commandDictionary.Add(command, newCommand);

                return newCommand;
            }
        }
    }
}
