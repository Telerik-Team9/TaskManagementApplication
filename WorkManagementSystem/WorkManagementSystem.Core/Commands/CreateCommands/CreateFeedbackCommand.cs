using System;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
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
            //List all boards
            this.InstanceFactory.Writer.WriteLine(this.ListAllBoards());
            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.ChooseBoardForWorkitem, "feedback"));

            this.InstanceFactory.Writer.Write(string.Format(CoreConstants.EnterBoardNameToAddWorkitemTo, "feedback"));
            string boardName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            IBoard board = this.InstanceFactory.Database
                .Boards
                .First(b => b.Name == boardName);

            this.InstanceFactory.Writer.WriteLine(CoreConstants.EnterFollowingParameters);

            (string title, string description) = ParseBaseWorkItemParameters();

            this.InstanceFactory.Writer.Write(CoreConstants.Rating);
            int rating = int.Parse(this.InstanceFactory.Reader.Read());
            IFeedback currentFeedback;


            this.InstanceFactory.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Status", "(Done/New/Scheduled/Unscheduled)"));
            string statusAsStr = this.InstanceFactory.Reader.Read();

            FeedbackStatus status;


            if (string.IsNullOrWhiteSpace(statusAsStr))
            {
                status = FeedbackStatus.New;
            }

            else if (!Enum.TryParse(statusAsStr, true, out status))
            {
                throw new InvalidEnumArgumentException("Invalid status");
            }

            currentFeedback = this.InstanceFactory.ModelsFactory.CreateFeedback(title, description, rating, status);
           
            board.AddWorkItem(currentFeedback);

            this.InstanceFactory.Database.Feedbacks.Add(currentFeedback);

            return string.Format(CoreConstants.CreatedWorkItem, "Feedback", title)
                + Environment.NewLine
                + currentFeedback.PrintInfo();
        }
    }
}

