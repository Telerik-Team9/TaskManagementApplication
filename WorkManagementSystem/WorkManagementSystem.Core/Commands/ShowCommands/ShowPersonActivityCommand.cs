using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowPersonActivityCommand : Command
    {
        public ShowPersonActivityCommand(IInstanceFactory instanceFactory) 
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IMember member = this.ChoosePerson();
            return member.PrintActivityHistory();
        }

        private IMember ChoosePerson()
        {
            this.Writer.WriteLine(this.ListAllMembers());

            this.Writer.WriteLine("\nSelect a person to see activity:");
            string personName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(person => person.Name == personName))
            {
                throw new ArgumentException("Person does not exist.");
            }

            IMember currPerson = this.InstanceFactory.Database
                .Members
                .First(person => person.Name == personName);

            return currPerson;
        }
    }
}
