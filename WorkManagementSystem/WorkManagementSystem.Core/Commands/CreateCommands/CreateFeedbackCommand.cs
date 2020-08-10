using System;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand()
            : base() { }

        public override string Execute()
        {
            this.Writer.WriteLine("Please enter the following parameters:");

            this.Writer.Write("Title: ");
            string title = this.Reader.Read();

            this.Writer.Write("Description: ");
            string description = this.Reader.Read();

            this.Writer.Write("Rating: ");
            int rating = int.Parse(this.Reader.Read());
            IFeedback currentFeedback;


            this.Writer.WriteLine("Status - Choose one of the following: " +
                "(Done/New/Scheduled/Unscheduled) or leave this field empty.");
            string statusAsStr = this.Reader.Read();

            FeedbackStatus status;

            if (!string.IsNullOrWhiteSpace(statusAsStr))
            {
                try
                {
                    status = Enum.Parse<FeedbackStatus>(statusAsStr, true);
                }
                catch
                {
                    throw new InvalidEnumArgumentException("Invalid status entered.");
                }
            }
            else
            {
                status = FeedbackStatus.New;
            }
            currentFeedback = this.Factory.CreateFeedback(title, description, rating, status);

            this.Database.Feedbacks.Add(currentFeedback);

            return $"Feedback with title '{title}' has been created.{NewLine}" + currentFeedback.PrintInfo();
        }
    }
}

