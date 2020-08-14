using System;
using System.Linq;
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
            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);
            return AddPersonToTeam(currTeam);
        }

        private string AddPersonToTeam(ITeam currTeam)
        {
            var showAllPeopele = new ShowAllPeopleCommand(this.InstanceFactory);// TODO: Remove this shit
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
