using System;
using WorkManagementSystem.Core.Commands.CreateCommands;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandName, IInstanceFactory instanceFactory)
        {
            return commandName.ToLower() switch
            {
                 "createbug" => new CreateBugCommand(instanceFactory),
                 "createfeedback" => new CreateFeedbackCommand(instanceFactory),
                 "createperson" => new CreatePersonCommand(instanceFactory),
                 "createstory" => new CreateStoryCommand(instanceFactory),
                 "createteam" => new CreateTeamCommand(instanceFactory),
                 
                 "showallpeople" => new ShowAllPeopleCommand(instanceFactory),

                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
