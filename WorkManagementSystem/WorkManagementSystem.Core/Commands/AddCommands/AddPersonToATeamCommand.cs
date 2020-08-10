using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.AddCommands
{
    public class AddPersonToATeamCommand : Command
    {
        public AddPersonToATeamCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException("There are currently no teams in the database.");
            }

            this.InstanceFactory.Writer.Write("Please select a team to add a new person to: "); // show all teams// TODO TEST
            this.InstanceFactory.Writer.WriteLine(this.ListAllTeams());

            string teamName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException($"The team {teamName} does not exist.");
            }

            ITeam currentTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);
            string personName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException($"A person with name {personName} does not exist in the database.");
            }

            if (!currentTeam.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException($"{personName} is already in {teamName} team.");
            }

            IMember member = this.InstanceFactory.Database
                .Members
                .First(p => p.Name == personName);

            currentTeam.AddPerson(member);

            return $"{personName} has been added to {teamName} team.";

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
