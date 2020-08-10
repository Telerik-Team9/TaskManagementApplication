using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
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
                throw new ArgumentException(CoreConstants.NoTeamsInDatabaseExcMessage);
            }

            this.Writer.WriteLine(this.ListAllTeams()); // show all teams// TODO TEST
            this.Writer.Write(CoreConstants.SelectTeamToAddPersonTo);

            string teamName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }

            ITeam currentTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);
            string personName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

            if (!currentTeam.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.PersonIsAlreadyOnTheTeamExcMessage, personName, teamName));
            }

            IMember member = this.InstanceFactory.Database
                .Members
                .First(p => p.Name == personName);

            currentTeam.AddPerson(member);

            return string.Format(CoreConstants.PersonAddedToATeam, personName, teamName);

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
