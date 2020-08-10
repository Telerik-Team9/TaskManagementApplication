using System;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {

            this.InstanceFactory.Writer.Write("Please select a board to add a feedback to: "); //List all boards
            string boardName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException($"A board with name {boardName} does not exist in the database.");
            }

            IBoard board = this.InstanceFactory.Database
                .Boards
                .First(b => b.Name == boardName);

            this.InstanceFactory.Writer.WriteLine("Please enter the following parameters to create a feedback:");

            this.InstanceFactory.Writer.Write("Title: ");
            string title = this.InstanceFactory.Reader.Read();

            this.InstanceFactory.Writer.Write("Description: ");
            string description = this.InstanceFactory.Reader.Read();

            this.InstanceFactory.Writer.Write("Rating: ");
            int rating = int.Parse(this.InstanceFactory.Reader.Read());
            IFeedback currentFeedback;


            this.InstanceFactory.Writer.WriteLine("Status - Choose one of the following: (Done/New/Scheduled/Unscheduled) or leave this field empty.");
            string statusAsStr = this.InstanceFactory.Reader.Read();

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
            currentFeedback = this.InstanceFactory.ModelsFactory.CreateFeedback(title, description, rating, status);

            board.AddWorkItem(currentFeedback);

            this.InstanceFactory.Database.Feedbacks.Add(currentFeedback);

            return $"Feedback with title '{title}' has been created.{Environment.NewLine}" + currentFeedback.PrintInfo();
        }
    }
}

