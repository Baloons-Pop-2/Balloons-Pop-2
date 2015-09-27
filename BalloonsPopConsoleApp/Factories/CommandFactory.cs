using System;
using System.Collections.Generic;
using BalloonsPop;
using BalloonsPop.Commands;
using BalloonsPopConsoleApp.Commands;

namespace BalloonsPopConsoleApp.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly Dictionary<string, ICommand> commandList = new Dictionary<string, ICommand>();

        public ICommand GetCommand(string command)
        {
            if (this.commandList.ContainsKey(command.ToLower()))
            {
                return this.commandList[command];
            }
            else
            {
                ICommand newCommand;

                switch (command.ToLower())
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
                    default:
                        throw new ArgumentException("Invalid command");
                }

                this.commandList.Add(command, newCommand);

                return newCommand;
            }
        }
    }
}
