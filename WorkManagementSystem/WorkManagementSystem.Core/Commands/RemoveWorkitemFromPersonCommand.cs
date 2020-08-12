using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands
{
    public class RemoveWorkitemFromPersonCommand : Command
    {
        public RemoveWorkitemFromPersonCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IMember member = this.ChoosePerson();
            return this.RemoveWorkitemFromPerson(member);

        }
        private IMember ChoosePerson()
        {
            var showAllPeopleCommand = new ShowAllPeopleCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllPeopleCommand.Execute());

            this.Writer.WriteLine("Please enter the person's name you wish to unassign a workitem from.");
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

        private string RemoveWorkitemFromPerson(IMember currPerson)
        {
            // TODO - not working - fix it!
            /* var workitems = new List<IWorkItem>();
             workitems.Concat(this.InstanceFactory.Database.Bugs)
                 .Concat(this.InstanceFactory.Database.Feedbacks)
                 .Concat(this.InstanceFactory.Database.Stories);*/

            IList<IWorkItem> workItems = this.InstanceFactory
                .Database
                .ListAllWorkitems();

            //lisr all workitems


            foreach (var item in workItems)
            {
                this.Writer.WriteLine(item.PrintInfo());
            }

            this.Writer.Write(string.Format("Enter workitem's id: "));
            int workItemId = int.Parse(this.Reader.Read());

            if (!workItems.Any(workitem => workitem.Id == workItemId))
            {
                throw new ArgumentException($"No workitem with id {workItemId}");
            }

            IWorkItem currWorkItem = workItems
                .First(workitem => workitem.Id == workItemId);

            currPerson.RemoveWorkitem(currWorkItem);
            currWorkItem.AddHistory($"Unassigned from {currPerson.Name}");


            return $"WorkItem {currWorkItem.Title} unassigned from {currPerson.Name}.";
        }
    }
}
