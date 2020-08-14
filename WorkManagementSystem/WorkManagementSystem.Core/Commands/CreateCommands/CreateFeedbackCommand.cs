using System;
using System.ComponentModel;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

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
            IBoard currBoard = ChooseMethods.ChooseBoard(this.InstanceFactory);
            return CreateFeedbackInBoard(currBoard);

        }

        private string CreateFeedbackInBoard(IBoard currBoard)
        {
            (string title, string description) = ParseBaseWorkItemParameters();

            this.Writer.Write(CoreConstants.Rating);
            int rating = int.Parse(this.Reader.Read());
            FeedbackStatus status = this.ParseEnums();

            IFeedback currFeedback = this.InstanceFactory.ModelsFactory.CreateFeedback(title, description, rating, status);

            this.InstanceFactory.Database.Feedbacks.Add(currFeedback);
            currBoard.AddWorkItem(currFeedback);


            string activity = string.Format(CoreConstants.CreatedWorkItem, "Feedback", currFeedback.Title);
            currFeedback.AddHistory(activity);

            return activity + NewLine
                + currFeedback.PrintInfo();
        }

        private FeedbackStatus ParseEnums()
        {
            // Parse Status
            this.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Status", "(Done/New/Scheduled/Unscheduled)"));
            string statusAsStr = this.Reader.Read();

            FeedbackStatus status;

            if (string.IsNullOrWhiteSpace(statusAsStr))
            {
                status = FeedbackStatus.New;
            }
            else if (!Enum.TryParse(statusAsStr, true, out status))
            {
                throw new InvalidEnumArgumentException("Invalid status");
            }

            return status;
        }
    }
}

