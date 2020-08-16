using System;
using System.Collections.Generic;
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

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory
                .Database
                .Teams
                .First(t=>t.Name == parameters[0]);

            return AddPersonToTeam(currTeam,parameters[1]);
        }

        public override IList<string> GetUserInput()
        {
            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);

            this.Writer.WriteLine(ListMethods.ListAllUnits(this.InstanceFactory, p => "Name: " + p.Name, "member"));

            this.Writer.WriteLine(string.Format("Enter person's name:"));
            string personName = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);
            parameters.Add(personName);

            return parameters;
        }

        private string AddPersonToTeam(ITeam currTeam, string personName)
        {

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

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
