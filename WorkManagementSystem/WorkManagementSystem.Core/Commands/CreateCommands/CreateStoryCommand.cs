using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
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

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory.Database.Teams.First(t => t.Name == parameters[0]);
            IBoard currBoard = this.InstanceFactory.Database.Boards.First(b => b.Name == parameters[1]);

            string title = parameters[2];
            string description = parameters[3];
            (Priority priority, StorySize size, StoryStatus status) = ParseEnums(parameters[4], parameters[5], parameters[6]);


            return CreateStoryInBoard(currBoard, title, description, priority, size, status);
        }

        private string CreateStoryInBoard(IBoard currBoard, string title, string description, Priority priority, StorySize size, StoryStatus status)
        {
            IStory currStory = this.InstanceFactory.ModelsFactory.CreateStory(title, description, priority, size, status);

            this.InstanceFactory.Database.Stories.Add(currStory);
            currBoard.AddWorkItem(currStory);

            return currStory.HistoryLog.First() + NewLine
                + currStory.PrintInfo();
        }

        private (Priority, StorySize, StoryStatus) ParseEnums(string priorityAsStr, string sizeAsStr, string statusAsStr)
        {
            //Parse priority
            Priority priority;

            if (string.IsNullOrWhiteSpace(priorityAsStr))
            {
                priority = Priority.Low;
            }
            else if (!Enum.TryParse(priorityAsStr, true, out priority))
            {
                throw new Exception("Invalid priority");
            }

            //Parse size
            StorySize size;

            if (string.IsNullOrWhiteSpace(sizeAsStr))
            {
                size = StorySize.Small;
            }
            else if (!Enum.TryParse(sizeAsStr, true, out size))
            {
                throw new Exception("Invalid size");
            }

            // Parse status
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

        public override IList<string> GetUserInput()
        {
            (IBoard currBoard, ITeam currTeam) = ChooseMethods.ChooseBoard(this.InstanceFactory);

            (string title, string description) = ParseBaseWorkItemParameters();

            // Get Priority
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Priority", "Low/Medium/High"));
            string priorityAsStr = this.InstanceFactory.Reader.Read();

            // Get Size
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Size", "Small/Medium/Large"));
            string sizeAsStr = this.InstanceFactory.Reader.Read();

            // Parse Status
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Status", "NotDone/InProgress/Done"));
            string statusAsStr = this.InstanceFactory.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);
            parameters.Add(currBoard.Name);
            parameters.Add(title);
            parameters.Add(description);
            parameters.Add(priorityAsStr);
            parameters.Add(sizeAsStr);
            parameters.Add(statusAsStr);

            return parameters;
        }
    }
}
