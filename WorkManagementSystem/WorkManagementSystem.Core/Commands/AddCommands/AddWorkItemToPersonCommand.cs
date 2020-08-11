using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.AddCommands
{
    public class AddWorkItemToPersonCommand : Command
    {
        public AddWorkItemToPersonCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IMember currPerson = ChoosePerson();
            return AddWorkItemToPerson(currPerson);
        }

        private IMember ChoosePerson()
        {
            var showAllPeopleCommand = new ShowAllPeopleCommand(this.InstanceFactory);
            this.Writer.Write(showAllPeopleCommand.Execute());

            this.Writer.WriteLine("Please enter the person's name you wish to assign a workitem to.");
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

        private string AddWorkItemToPerson(IMember currPerson)
        {
            // TODO - not working - fix it!
            var workitems = new List<IWorkItem>();
            workitems.Concat(this.InstanceFactory.Database.Bugs)
                .Concat(this.InstanceFactory.Database.Feedbacks)
                .Concat(this.InstanceFactory.Database.Stories);

            //lisr all workitems

            this.Writer.WriteLine(string.Format("Enter workitem's id:"));
            int workItemId = Convert.ToInt32(this.Reader.Read());

            if (!workitems.Any(workitem => workitem.Id == workItemId))
            {
                throw new ArgumentException("No workitem with this id");
            }

            IWorkItem currWorkItem = workitems
                .First(workitem => workitem.Id == workItemId);

            currPerson.AddWorkItem(currWorkItem);

            return $"WorkItem {currWorkItem.Title} assigned to {currPerson.Name}.";
        }
    }
}
