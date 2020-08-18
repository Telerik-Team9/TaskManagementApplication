using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.RemoveCommands
{
    public class RemoveWorkitemFromPersonCommand : Command
    {
        public RemoveWorkitemFromPersonCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            IMember currMember = this.InstanceFactory
                .Database
                .Members
                .First(p => p.Name == parameters[0]);

            return this.RemoveWorkitemFromPerson(currMember, parameters[1]);
        }

        public override IList<string> GetUserInput()
        {
            IMember currPerson = ChooseMethods.ChoosePerson(this.InstanceFactory);

            if (!currPerson.WorkItems.Any())
            {
                throw new ArgumentException("Person has no workitems assigned.");
            }

            foreach (var item in currPerson.WorkItems)
            {
                this.Writer.WriteLine(item.PrintInfo());
            }

            this.Writer.Write(string.Format("Enter workitem's id: "));
            string workItemId = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currPerson.Name);
            parameters.Add(workItemId);

            return parameters;
        }

        private string RemoveWorkitemFromPerson(IMember currPerson, string workItemId)
        {
            IList<IWorkItem> workItems = this.InstanceFactory //TODO
               .Database
               .ListAllWorkitems();

            if (!workItems.Any(workitem => workitem.Id == int.Parse(workItemId)))
            {
                throw new ArgumentException($"No workitem with id {workItemId}");
            }

            IWorkItem currWorkItem = currPerson
                .WorkItems
                .First(workitem => workitem.Id == int.Parse(workItemId));

            var bug = currWorkItem as IBug;
            var story = currWorkItem as IStory;

            if (bug != null)
            {
                bug.RemoveAssignee(currPerson);
            }

            if (story != null)
            {
                story.RemoveAssignee(currPerson);
            }

            currPerson.RemoveWorkItem(currWorkItem);

            return $"WorkItem {currWorkItem.Title} unassigned from {currPerson.Name}.";
        }
    }
}
