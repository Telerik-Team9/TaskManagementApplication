using System;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
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
            IBoard currBoard = ChooseBoard();
            return CreateFeedbackInBoard(currBoard);

            /*//List all boards
            this.Writer.WriteLine(this.ListAllBoards());
            this.Writer.WriteLine(string.Format(CoreConstants.ChooseBoardForWorkitem, "feedback"));

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            IBoard board = this.InstanceFactory.Database
                .Boards
                .First(b => b.Name == boardName);*/


        }

        private IBoard ChooseBoard()
        {
            if (!this.InstanceFactory.Database.Boards.Any())
            {
                throw new ArgumentException("There are no boards.");
            }

            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());

            this.Writer.WriteLine(NewLine + string.Format(CoreConstants.ChooseBoardForWorkitem, "bug"));

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            IBoard currBoard = this.InstanceFactory.Database
                .Boards
                .First(b => b.Name == boardName);

            return currBoard;
        }

        private string CreateFeedbackInBoard(IBoard currBoard)
        {
            this.Writer.WriteLine(CoreConstants.EnterFollowingParameters);

            (string title, string description) = ParseBaseWorkItemParameters();

            this.Writer.Write(CoreConstants.Rating);
            int rating = int.Parse(this.Reader.Read());
            FeedbackStatus status = this.ParseEnums();

            IFeedback currFeedback = this.InstanceFactory.ModelsFactory.CreateFeedback(title, description, rating, status);

            currBoard.AddWorkItem(currFeedback);

            this.InstanceFactory.Database.Feedbacks.Add(currFeedback);

            return string.Format(CoreConstants.CreatedWorkItem, "Feedback", title) + NewLine
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

