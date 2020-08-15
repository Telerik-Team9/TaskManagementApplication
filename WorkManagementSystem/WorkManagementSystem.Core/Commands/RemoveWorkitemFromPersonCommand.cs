using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
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
            IMember member = ChooseMethods.ChoosePerson(this.InstanceFactory);
            return this.RemoveWorkitemFromPerson(member);

        }
        private string RemoveWorkitemFromPerson(IMember currPerson)
        {
            IList<IWorkItem> workItems = this.InstanceFactory
                .Database
                .ListAllWorkitems();

            //lisr all workitems //TODO

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
