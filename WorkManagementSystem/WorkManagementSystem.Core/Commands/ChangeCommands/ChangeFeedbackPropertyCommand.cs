using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
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
            IFeedback currFeedback = this.ChooseFeedback();
            return AlterFeedback(currFeedback);
        }
        private string AlterFeedback(IFeedback feedback)
        {
            this.Writer.WriteLine($"Rating: {feedback.Rating}|Status: {feedback.FeedbackStatus}\n");
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

        private IFeedback ChooseFeedback()
        {
            this.Writer.WriteLine(this.ListAllFeedbacks());

            this.Writer.Write("Please type in the ID of the bug you want to change: ");
            string idAsStr = this.Reader.Read();

            if (!this.InstanceFactory.Database.Feedbacks.Any(b => b.Id == int.Parse(idAsStr)))
            {
                throw new ArgumentException("You have entered wrong ID.");
            }

            IFeedback currFeedback = this.InstanceFactory
                .Database
                .Feedbacks
                .First(b => b.Id == int.Parse(idAsStr));

            return currFeedback;
        }

        private string ListAllFeedbacks()
        {
            if (!this.InstanceFactory.Database.Feedbacks.Any())
            {
                throw new ArgumentException("There are no feedbacks.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var feedback in this.InstanceFactory.Database.Feedbacks)
            {
                sb.AppendLine($"ID: {feedback.Id}|Title: {feedback.Title}|Rating: {feedback.Rating}|Status: {feedback.FeedbackStatus}");
            }
            sb.AppendLine("++++++++++++++++++++++++++++++++++++++++++++");

            return sb.ToString().TrimEnd();
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
