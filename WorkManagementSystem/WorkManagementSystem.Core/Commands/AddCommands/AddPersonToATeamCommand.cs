using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.AddCommands
{
    public class AddPersonToATeamCommand : Command
    {
        public AddPersonToATeamCommand() { }

        public override string Execute()
        {
            if (!this.Database.Teams.Any())
            {
                throw new ArgumentException("There are currently no teams in the database.");
            }

            this.Writer.Write("Please select a team to add a new person to: "); // show all teams// TODO TEST
            this.Writer.WriteLine(this.ListAllTeams());

            string teamName = this.Reader.Read();

            if (!this.Database.Teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"The team {teamName} does not exist.");
            }

            ITeam currentTeam = this.Database
                .Teams
                .First(t => t.Name == teamName);
            string personName = this.Reader.Read();

            if (!this.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException($"A person with name {personName} does not exist in the database.");
            }

            if (!currentTeam.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException($"{personName} is already in {teamName} team.");
            }

            IMember member = this.Database
                .Members
                .First(p => p.Name == personName);

            currentTeam.AddPerson(member);

            return $"{personName} has been added to {teamName} team.";

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
