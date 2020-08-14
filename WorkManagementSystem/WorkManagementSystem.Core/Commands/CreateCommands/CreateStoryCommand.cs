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
            IBoard currBoard = ChooseMethods.ChooseBoard(this.InstanceFactory);
            return CreateStoryInBoard(currBoard);
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
