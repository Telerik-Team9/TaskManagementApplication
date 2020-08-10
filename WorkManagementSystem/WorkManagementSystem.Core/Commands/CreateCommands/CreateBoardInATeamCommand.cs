using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateBoardInATeamCommand : Command
    {
        public CreateBoardInATeamCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {

            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException(CoreConstants.NoTeamsInDatabaseExcMessage);
            }

            this.InstanceFactory.Writer.Write(CoreConstants.SelectTeamToAddBoardTo); // show all teams// TODO TEST
            this.InstanceFactory.Writer.WriteLine(this.ListAllTeams());

            string teamName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }

            ITeam currentTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);

            this.InstanceFactory.Writer.Write(CoreConstants.EnterBoardName);
            string boardName = this.InstanceFactory.Reader.Read();

            if (currentTeam.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardAlreadyExistsExcMessage, boardName, teamName));
            }

            IBoard currBoard = this.InstanceFactory.ModelsFactory.CreateBoard(boardName);
            currentTeam.AddBoard(currBoard);

            this.InstanceFactory.Database.Boards.Add(currBoard);

            string activity = string.Format(CoreConstants.CreatedBoard, boardName, teamName);
            currBoard.AddActivityLog(activity);

            return activity
                + Environment.NewLine
                + currBoard.PrintInfo();
        }

        private string ListAllTeams()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var t in this.InstanceFactory.Database.Teams)
            {
                sb.AppendLine(t.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
