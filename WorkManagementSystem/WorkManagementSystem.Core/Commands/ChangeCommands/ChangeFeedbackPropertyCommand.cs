using System;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ChangeCommands
{
    public class ChangeFeedbackPropertyCommand : Command
    {
        public ChangeFeedbackPropertyCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IFeedback currFeedback = ChooseMethods.ChooseFeedback(this.InstanceFactory);
            return AlterFeedback(currFeedback);
        }
        private string AlterFeedback(IFeedback feedback)
        {
            this.Writer.WriteLine($"Rating: {feedback.Rating}|Status: {feedback.Status}\n");
            this.Writer.WriteLine("Choose which property you wish to change: (rating/status)");

            string propertyToChange = this.Reader.Read();
            this.Writer.WriteLine(ValidatePropertyType(propertyToChange));

            string newValue = this.Reader.Read();

            if (int.TryParse(newValue, out int rating))
            {
                feedback.ChangeRating(rating);
            }

            else if (Enum.TryParse(newValue, ignoreCase: true, out FeedbackStatus status))
            {
                feedback.ChangeStatus(status);
            }

            else
            {
                throw new ArgumentException("Invalid value entered.");
            }

            return $"Feedback {propertyToChange} set to {newValue}";
        }

        private string ValidatePropertyType(string value)
        {
            return value.ToLower() switch
            {
                "rating" => "[1 - 10]",
                "status" => "(new/unscheduled/scheduled/done)",

                _ => throw new ArgumentException("Invalid property entered!")
            };
        }

    }
}
