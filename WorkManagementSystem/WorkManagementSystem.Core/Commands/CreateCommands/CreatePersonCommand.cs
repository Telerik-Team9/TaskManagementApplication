using System;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            this.Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "person"));

            string personName = this.Reader.Read();

            if (this.InstanceFactory.Database.Members.Any(m => m.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberAlreadyExistsExcMessage, personName));
            }

            IMember currMember = this.InstanceFactory.ModelsFactory.CreatePerson(personName);
            this.InstanceFactory.Database.Members.Add(currMember);

            string activity = string.Format(CoreConstants.CreatedMember, personName);
            currMember.AddActivityLog(activity);

            return activity
                + NewLine
                + currMember.PrintInfo();
        }
    }
}
