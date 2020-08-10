using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateStoryCommand : Command
    {
        /*public CreateStoryCommand(IList<string> commandParameters)
            : base(commandParameters) { }*/

        public CreateStoryCommand()
           : base()
        {
        }

        public override string Execute()
        {
/*            this.Writer.WriteLine("Please enter the following parameters:");

            this.Writer.Write("Title: ");
            string title = this.Reader.Read();

            this.Writer.Write("Description: ");
            string description = this.Reader.Read();

            this.Writer.Write("Rating: ");
            int rating = int.Parse(this.Reader.Read());
            IFeedback currentFeedback;

            // Parse Priority
            this.Writer.WriteLine("Status - Choose one of the following: " +
                "(Done/New/Scheduled/Unscheduled) or leave this field empty.");
            string priorityAsStr = this.Reader.Read();

            Priority priority;

            if (string.IsNullOrWhiteSpace(priorityAsStr))
            {
                priority = Priority.Low;
            }
            else if (!Enum.TryParse(priorityAsStr, true, out priority))
            {
                throw new Exception("Invalid category");
            }

            // Parse Priority
            StorySize size;

            if (string.IsNullOrWhiteSpace(priorityAsStr))
            {
                size = StorySize.Small;
            }
            else if (!Enum.TryParse(priorityAsStr, true, out size))
            {
                throw new Exception("Invalid category");
            }

            currentFeedback = this.Factory.CreateFeedback(title, description, rating, status);

            this.Database.Feedbacks.Add(currentFeedback);

            return $"Feedback with title '{title}' has been created.{Environment.NewLine}" + currentFeedback.PrintInfo();*/
            throw new NotImplementedException();
        }
    }
}
