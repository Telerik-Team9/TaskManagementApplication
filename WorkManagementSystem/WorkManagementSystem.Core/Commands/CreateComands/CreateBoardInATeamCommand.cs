using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateComands
{
    public class CreateBoardInATeamCommand : Command
    {
        public CreateBoardInATeamCommand() { }

        public override string Execute()
        {

            if (!this.Database.Teams.Any())
            {
                throw new ArgumentException("There are currently no teams in the database.");
            }

            this.Writer.Write("Please select a team to add a new board to: "); // show all teams// TODO TEST
            this.Writer.WriteLine(this.ListAllTeams());

            string teamName = this.Reader.Read();

            if (!this.Database.Teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"The team {teamName} does not exist.");
            }

            ITeam currentTeam = this.Database
                .Teams
                .First(t => t.Name == teamName);

            this.Writer.Write("Please enter board name:");
            string boardName = this.Reader.Read();

            if (currentTeam.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException($"A board with name {boardName} already exists in team {teamName}");
            }

            IBoard board = this.Factory.CreateBoard(boardName);
            currentTeam.AddBoard(board);

            this.Database.Boards.Add(board);

            return $"A board with name '{boardName}' has been added to {teamName} team.";
        }

        private string ListAllTeams()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var t in this.Database.Teams)
            {
                sb.AppendLine(t.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
