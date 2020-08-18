using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ChangeCommands
{
    public class ChangeFeedbackPropertyCommand : Command
    {
        public ChangeFeedbackPropertyCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            IFeedback currFeedback = this.InstanceFactory.Database.Feedbacks.First(f => f.Id == int.Parse(parameters[0]));

            return AlterFeedback(currFeedback, parameters[1], parameters[2]);
        }

        private string AlterFeedback(IFeedback feedback, string propertyToChange, string newValue)
        {
            // TODO: in future use we should get te property from "propertyToChange"
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

        public override IList<string> GetUserInput()
        {
            IFeedback currFeedback = ChooseMethods.ChooseFeedback(this.InstanceFactory);

            this.Writer.WriteLine($"Rating: {currFeedback.Rating}|Status: {currFeedback.Status}\n");
            this.Writer.WriteLine("Choose which property you wish to change: (rating/status)");

            string propertyToChange = this.Reader.Read();
            this.Writer.WriteLine(ValidatePropertyType(propertyToChange));

            string newValue = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currFeedback.Id.ToString());
            parameters.Add(propertyToChange);
            parameters.Add(newValue);

            return parameters;
        }
    }
}
