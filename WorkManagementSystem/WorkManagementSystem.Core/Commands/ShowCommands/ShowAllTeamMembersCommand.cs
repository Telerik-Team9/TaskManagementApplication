using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamMembersCommand : Command
    {
        public ShowAllTeamMembersCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException($"There are no teams.");
            }

            this.Writer.WriteLine("Please enter the team's name");
            string teamName = this.Reader.Read();

            // TODO : Better way to do this?
            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException($"There is no team with that name.");
            }

            ITeam currTeam = this.InstanceFactory.Database.Teams.First(team => team.Name == teamName);

            if (!currTeam.Members.Any())
            {
                throw new ArgumentException($"There are no members in team '{teamName}'.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var member in currTeam.Members)
            {
                sb.AppendLine(member.PrintInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
