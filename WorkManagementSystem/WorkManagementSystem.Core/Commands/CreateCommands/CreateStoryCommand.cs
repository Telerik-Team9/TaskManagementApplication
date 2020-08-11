using System;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IBoard currBoard = ChooseBoard();
            return CreateStoryInBoard(currBoard);
        }

        private IBoard ChooseBoard()
        {
            if (!this.InstanceFactory.Database.Boards.Any())
            {
                throw new ArgumentException("There are no boards.");
            }

            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());

            //list teams

            this.Writer.WriteLine("Please select a team from the list above.");
            string teamName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }
            //extract team
            ITeam currTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);

            this.Writer.WriteLine(NewLine + string.Format(CoreConstants.ChooseBoardForWorkitem, "story"));

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            //return board in a team

            IBoard teamBoard = currTeam
                .Boards
                .FirstOrDefault(b => b.Name == boardName);

            return teamBoard;
        }

        private string CreateStoryInBoard(IBoard currBoard)
        {
            (string title, string description) = ParseBaseWorkItemParameters();
            (Priority priority, StorySize size, StoryStatus status) = ParseEnums();


            IStory currStory = this.InstanceFactory.ModelsFactory.CreateStory(title, description, priority, size, status);

            this.InstanceFactory.Database.Stories.Add(currStory);
            currBoard.AddWorkItem(currStory);

            string activity = string.Format(CoreConstants.CreatedWorkItem, "Story", currStory.Title);
            currStory.AddHistory(activity);

            return activity + NewLine
                + currStory.PrintInfo();
        }

        private (Priority, StorySize, StoryStatus) ParseEnums()
        {
            // Parse Priority
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Priority", "Low/Medium/High"));
            string priorityAsStr = this.InstanceFactory.Reader.Read();
            Priority priority;

            if (string.IsNullOrWhiteSpace(priorityAsStr))
            {
                priority = Priority.Low;
            }
            else if (!Enum.TryParse(priorityAsStr, true, out priority))
            {
                throw new Exception("Invalid priority");
            }

            // Parse Size
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Size", "Small/Medium/Large"));
            string sizeAsStr = this.InstanceFactory.Reader.Read();
            StorySize size;

            if (string.IsNullOrWhiteSpace(sizeAsStr))
            {
                size = StorySize.Small;
            }
            else if (!Enum.TryParse(sizeAsStr, true, out size))
            {
                throw new Exception("Invalid size");
            }

            // Parse Status
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Status", "NotDone/InProgress/Done"));
            string statusAsStr = this.InstanceFactory.Reader.Read();
            StoryStatus status;

            if (string.IsNullOrWhiteSpace(statusAsStr))
            {
                status = StoryStatus.NotDone;
            }
            else if (!Enum.TryParse(statusAsStr, true, out status))
            {
                throw new Exception("Invalid status");
            }

            return (priority, size, status);
        }
    }
}
