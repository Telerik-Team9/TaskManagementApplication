using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandName)
        {
            return commandName.ToLower() switch
            {
                // "createmember" => new CreatePersonCommand()
                /* "createteam" => new CreateTeamCommand(commandParameters),
                 "showallpeople" => new ShowAllPeopleCommand(commandParameters),
                 "createbug" => new CreateBugCommand(commandParameters)*/
                // "createfeedback" => new CreateFeedbackCommand(),
                //  _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
