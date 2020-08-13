using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.AddCommands
{
    public class AddPersonToTeamCommand : Command
    {
        public AddPersonToTeamCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            ITeam currTeam = ChooseTeam();
            return AddPersonToTeam(currTeam);
        }

        private ITeam ChooseTeam()
        {
            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());

            this.Writer.WriteLine("Please enter the team's name to add the person to.");
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

        private string AddPersonToTeam(ITeam currTeam)
        {
            var showAllPeopele = new ShowAllPeopleCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllPeopele.Execute());

            this.Writer.WriteLine(string.Format("Please enter person's name:"));
            string personName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

            // Check / debug
            if (currTeam.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.PersonIsAlreadyOnTheTeamExcMessage, personName, currTeam.Name));
            }

            IMember member = this.InstanceFactory.Database.Members
                .First(p => p.Name == personName);

            currTeam.AddPerson(member);

            string activity = string.Format(CoreConstants.PersonAddedToATeam, personName, currTeam.Name);
            member.AddActivityLog(activity);

            return activity;
        }
    }
}
