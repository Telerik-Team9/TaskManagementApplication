using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory.Database.Teams.First(t => t.Name == parameters[0]);
            IBoard currBoard = this.InstanceFactory.Database.Boards.First(b => b.Name == parameters[1]);

            string title = parameters[2];
            string description = parameters[3];
            int rating = int.Parse(parameters[4]);
            FeedbackStatus status = ParseEnums(parameters[5]);

            return CreateFeedbackInBoard(currBoard, title, description, rating, status);
        }

        private string CreateFeedbackInBoard(IBoard currBoard, string title, string description, int rating, FeedbackStatus status)
        {
            IFeedback currFeedback = this.InstanceFactory.ModelsFactory.CreateFeedback(title, description, rating, status);

            this.InstanceFactory.Database.Feedbacks.Add(currFeedback);
            currBoard.AddWorkItem(currFeedback);

            return currFeedback.HistoryLog.First() + NewLine
                + currFeedback.PrintInfo();
        }

        private FeedbackStatus ParseEnums(string statusAsStr)
        {
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

        public override IList<string> GetUserInput()
        {
            (IBoard currBoard, ITeam currTeam) = ChooseMethods.ChooseBoard(this.InstanceFactory);

            (string title, string description) = ParseBaseWorkItemParameters();

            this.Writer.WriteLine(CoreConstants.Rating);
            string rating = this.Reader.Read();

            this.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Status", "(Done/New/Scheduled/Unscheduled)"));
            string statusAsStr = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);
            parameters.Add(currBoard.Name);
            parameters.Add(title);
            parameters.Add(description);
            parameters.Add(rating);
            parameters.Add(statusAsStr);

            return parameters;
        }
    }
}