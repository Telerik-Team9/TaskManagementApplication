using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamBoardsCommand : Command
    {
        public ShowAllTeamBoardsCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            ITeam currTeam = ChooseTeam();
            return ShowAllTeamBoards(currTeam);
        }

        private ITeam ChooseTeam()
        {
            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.Write(showAllTeamsCommand.Execute());

            this.Writer.WriteLine("Please enter the team's name to show all it's boards.");
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

        private string ShowAllTeamBoards(ITeam currTeam)
        {
            if (!currTeam.Boards.Any())
            {
                throw new ArgumentException($"There are no boards in team '{currTeam.Name}'.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var board in currTeam.Boards)
            {
                sb.AppendLine(board.PrintInfo() + NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
