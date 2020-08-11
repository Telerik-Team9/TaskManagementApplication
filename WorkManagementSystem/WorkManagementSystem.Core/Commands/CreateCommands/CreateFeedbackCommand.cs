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

        }

        private IBoard ChooseBoard()
        {
            if (!this.InstanceFactory.Database.Boards.Any())
            {
                throw new ArgumentException("There are no boards.");
            }

            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());
            //list teams

            this.Writer.WriteLine("Please select a team from the list above.");
            string teamName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }
            //extract team
            ITeam currTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);


            this.Writer.WriteLine(NewLine + string.Format(CoreConstants.ChooseBoardForWorkitem, "feedback"));

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            //return board in a team

            IBoard teamBoard = currTeam
                .Boards
                .FirstOrDefault(b => b.Name == boardName);
            
            return teamBoard;
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

