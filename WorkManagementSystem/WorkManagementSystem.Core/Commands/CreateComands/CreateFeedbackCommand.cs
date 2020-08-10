using System;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateComands
{
    class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand() { }

        public override string Execute()
        {

            this.Writer.Write("Please select a board to add a feedback to: "); //List all boards
            string boardName = this.Reader.Read();

            if (!this.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException($"A board with name {boardName} does not exist in the database.");
            }

            IBoard board = this.Database
                .Boards
                .First(b => b.Name == boardName);

            this.Writer.WriteLine("Please enter the following parameters to create a feedback:");

            this.Writer.Write("Title: ");
            string title = this.Reader.Read();

            this.Writer.Write("Description: ");
            string description = this.Reader.Read();

            this.Writer.Write("Rating: ");
            int rating = int.Parse(this.Reader.Read());
            IFeedback currentFeedback;


            this.Writer.WriteLine("Status - Choose one of the following: (Done/New/Scheduled/Unscheduled) or leave this field empty.");
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

            board.AddWorkItem(currentFeedback);

            this.Database.Feedbacks.Add(currentFeedback);

            return $"Feedback with title '{title}' has been created.{Environment.NewLine}" + currentFeedback.PrintInfo();
        }
    }
}

