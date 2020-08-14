using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ChangeCommands
{
    public class ChangeStoryPropertyCommand : Command
    {
        public ChangeStoryPropertyCommand(IInstanceFactory instanceFactory) 
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IStory currStory = ChooseMethods.ChooseStory(this.InstanceFactory);
            return this.AlterStory(currStory);
        }

        private string AlterStory(IStory story)
        {
            //this.Writer.WriteLine($"Priority: {bug.Priority}|Severity: {bug.Severity}|Status: {bug.Status}\n");
            this.Writer.WriteLine("Choose which property you wish to change: (priority/size/status)");

            string propertyToChange = this.Reader.Read();
            this.Writer.WriteLine(ValidatePropertyType(propertyToChange));

            string newValue = this.Reader.Read();

            if (Enum.TryParse(newValue, ignoreCase: true, out Priority priority))
            {
                story.ChangePriority(priority);
            }

            else if (Enum.TryParse(newValue, ignoreCase: true, out StorySize size))
            {
                story.ChangeSize(size);
            }

            else if (Enum.TryParse(newValue, ignoreCase: true, out StoryStatus status))
            {
                story.ChangeStatus(status);
            }

            else
            {
                throw new ArgumentException("Invalid value entered.");
            }

            return $"Story {propertyToChange} set to {newValue}";
        }

        private string ValidatePropertyType(string value)
        {
            return value.ToLower() switch
            {
                "priority" => "(high/medium/low)",
                "size" => "(large/medium/small)",
                "status" => "(notdone/inprogress/done)",

                _ => throw new ArgumentException("Invalid property entered!")
            };
        }
    }
}
