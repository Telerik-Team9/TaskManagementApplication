using System;
using WorkManagementSystem.Core.Commands;
using WorkManagementSystem.Core.Commands.CreateComands;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandName)
        {
            return commandName.ToLower() switch
            {
                 "createperson" => new CreatePersonCommand(),
                 "createfeedback" => new CreateFeedbackCommand(),

                /* "createteam" => new CreateTeamCommand(commandParameters),
                 "showallpeople" => new ShowAllPeopleCommand(commandParameters),
                 "createbug" => new CreateBugCommand(commandParameters)*/
                // "createfeedback" => new CreateFeedbackCommand(),
                  _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
