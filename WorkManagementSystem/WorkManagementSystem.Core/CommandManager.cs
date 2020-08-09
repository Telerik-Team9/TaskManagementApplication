using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();


            // TODO: Reflection!
            return commandName switch
            {
                "createperson" => new CreatePersonCommand(commandParameters),
                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
