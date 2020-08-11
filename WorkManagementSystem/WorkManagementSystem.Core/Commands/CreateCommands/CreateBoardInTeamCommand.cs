using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateBoardInTeamCommand : Command
    {
        public CreateBoardInTeamCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            ITeam currTeam = ChooseTeam();
            return CreateBoardInTeam(currTeam);
        }

        private ITeam ChooseTeam()
        {
            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());

            this.Writer.WriteLine("Please enter the team's name to add the board to.");
            string teamName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }

            ITeam currTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);

            return currTeam;
        }

        private string CreateBoardInTeam(ITeam currTeam)
        {
            this.Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "board"));
            string boardName = this.Reader.Read();

            if (currTeam.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardAlreadyExistsExcMessage, boardName, currTeam.Name));
            }

            IBoard currBoard = this.InstanceFactory.ModelsFactory.CreateBoard(boardName);
            currTeam.AddBoard(currBoard);

            this.InstanceFactory.Database.Boards.Add(currBoard);

            string activity = string.Format(CoreConstants.CreatedBoard, boardName, currTeam.Name);
            currBoard.AddActivityLog(activity);

            return activity + NewLine
                + currBoard.PrintInfo();
        }
    }
}
