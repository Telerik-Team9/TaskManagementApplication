using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
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
                throw new ArgumentException("There are currently no teams in the database.");
            }

            this.InstanceFactory.Writer.Write("Please select a team to add a new board to: "); // show all teams// TODO TEST
            this.InstanceFactory.Writer.WriteLine(this.ListAllTeams());

            string teamName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"The team {teamName} does not exist.");
            }

            ITeam currentTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);

            this.InstanceFactory.Writer.Write("Please enter board name:");
            string boardName = this.InstanceFactory.Reader.Read();

            if (currentTeam.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException($"A board with name {boardName} already exists in team {teamName}");
            }

            IBoard board = this.InstanceFactory.ModelsFactory.CreateBoard(boardName);
            currentTeam.AddBoard(board);

            this.InstanceFactory.Database.Boards.Add(board);

            return $"A board with name '{boardName}' has been added to {teamName} team.";
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
