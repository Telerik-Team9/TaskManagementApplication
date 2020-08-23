using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.AddCommands;
using WorkManagementSystem.Core.Commands.ChangeCommands;
using WorkManagementSystem.Core.Commands.CreateCommands;
using WorkManagementSystem.Core.Commands.ListCommands;
using WorkManagementSystem.Core.Commands.RemoveCommands;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.Core
{
    public class CommandManager : ICommandManager
    {
        private static readonly IInstanceFactory factory = new InstanceFactory();
        private static readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>()
        {
            {"createboardinteam" , new CreateBoardInTeamCommand(factory) },
            {"createbug" , new CreateBugCommand(factory) },
            {"createfeedback" , new CreateFeedbackCommand(factory) },
            {"createstory" , new CreateStoryCommand(factory) },
            {"createperson" , new CreatePersonCommand(factory) },
            {"createteam" , new CreateTeamCommand(factory) },
            {"showallpeople" , new ShowAllPeopleCommand(factory) },
            {"showallteams" , new ShowAllTeamsCommand(factory) },
            {"showallteammembers" , new ShowAllTeamMembersCommand(factory) },
            {"showallteamboards" , new ShowAllTeamBoardsCommand(factory) },
            {"showpersonactivity" , new ShowPersonActivityCommand(factory) },
            {"showboardactivity" , new ShowBoardActivityCommand(factory) },
            {"showteamactivity" , new ShowTeamActivityCommand(factory) },
            {"addpersontoteam" , new AddPersonToTeamCommand(factory) },
            {"addworkitemtoperson" , new AddWorkItemToPersonCommand(factory) },
            {"addcommenttoworkitem" , new AddCommentToWorkItemCommand(factory) },
            {"removeworkitemfromperson" , new RemoveWorkitemFromPersonCommand(factory) },
            {"changebugproperty" , new ChangeBugPropertyCommand(factory) },
            {"changefeedbackproperty" , new ChangeFeedbackPropertyCommand(factory) },
            {"changestoryproperty" , new ChangeStoryPropertyCommand(factory) },
            {"listworkitems" , new ListWorkItemsCommand(factory) },
            {"listbugs" , new ListBugsCommand(factory) },
            {"listfeedbacks" , new ListFeedbacksCommand(factory) },
            {"liststories" , new ListStoriesCommand(factory) },
        };

        public ICommand ParseCommand(string commandName, IInstanceFactory instanceFactory)
        {
            if (!commands.ContainsKey(commandName.ToLower()))
            {
                if (commandName == "exit")
                {
                    instanceFactory.Writer.Write("Have a nice day!");
                    Environment.Exit(0);
                }

                throw new ArgumentException("Command does not exist");
            }

            ICommand executeCommand = commands.First(x => x.Key == commandName).Value;
            return executeCommand;
        }
    }
}
/*return commandName.ToLower() switch
            {
                "createboardinteam" => new CreateBoardInTeamCommand(instanceFactory),
                "createbug" => new CreateBugCommand(instanceFactory),
                "createfeedback" => new CreateFeedbackCommand(instanceFactory),
                "createperson" => new CreatePersonCommand(instanceFactory),
                "createstory" => new CreateStoryCommand(instanceFactory),
                "createteam" => new CreateTeamCommand(instanceFactory),

                "showallpeople" => new ShowAllPeopleCommand(instanceFactory),
                "showallteams" => new ShowAllTeamsCommand(instanceFactory),
                "showallteammembers" => new ShowAllTeamMembersCommand(instanceFactory),
                "showallteamboards" => new ShowAllTeamBoardsCommand(instanceFactory),
                "showpersonactivity" => new ShowPersonActivityCommand(instanceFactory),
                "showboardactivity" => new ShowBoardActivityCommand(instanceFactory),
                "showteamactivity" => new ShowTeamActivityCommand(instanceFactory),

                "addpersontoteam" => new AddPersonToTeamCommand(instanceFactory),
                "addworkitemtoperson" => new AddWorkItemToPersonCommand(instanceFactory),
                "addcommenttoworkitem" => new AddCommentToWorkItemCommand(instanceFactory),
                "removeworkitemfromperson" => new RemoveWorkitemFromPersonCommand(instanceFactory),

                "changebugproperty" => new ChangeBugPropertyCommand(instanceFactory),
                "changefeedbackproperty" => new ChangeFeedbackPropertyCommand(instanceFactory),
                "changestoryproperty" => new ChangeStoryPropertyCommand(instanceFactory),

                "listworkitems" => new ListWorkItemsCommand(instanceFactory),
                "listbugs" => new ListBugsCommand(instanceFactory),
                "listfeedbacks" => new ListFeedbacksCommand(instanceFactory),
                "liststories" => new ListStoriesCommand(instanceFactory),

                _ => throw new InvalidOperationException("Command does not exist")
            };*/
