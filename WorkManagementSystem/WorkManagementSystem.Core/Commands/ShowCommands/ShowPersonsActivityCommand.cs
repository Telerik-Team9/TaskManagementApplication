using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowPersonsActivityCommand : Command
    {
        public ShowPersonsActivityCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IMember member = this.ChoosePerson();
            return this.ReturnActivity(member);
        }

        private IMember ChoosePerson()
        {
            var showAllPeopleCommand = new ShowAllPeopleCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllPeopleCommand.Execute());

            this.Writer.WriteLine("Please enter the person's name you wish to see activity.");
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
        private string ReturnActivity(IMember member)
        {
            var sb = new StringBuilder();

            foreach (var item in member.ActivityHistory)
            {
                sb.AppendLine($"{item.ActivityMessage}|{item.ActivityTime}");
            }

            return sb.ToString().Trim();
        }
    }
}
