using System;
using WorkManagementSystem.Core.Commands.CreateCommands;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandName)
        {
            return commandName.ToLower() switch
            {
                 "createbug" => new CreateBugCommand(),
                 "createfeedback" => new CreateFeedbackCommand(),
                 "createperson" => new CreatePersonCommand(),
                 "createstory" => new CreateStoryCommand(),
                 "createteam" => new CreateTeamCommand(),
                 
                 "showallpeople" => new ShowAllPeopleCommand(),

                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
