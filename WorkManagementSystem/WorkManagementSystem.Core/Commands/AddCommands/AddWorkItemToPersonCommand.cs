using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
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

        public override string Execute(IList<string> parameters)
        {
            IMember currMember = this.InstanceFactory
                .Database
                .Members
                .First(p => p.Name == parameters[0]);

            return this.AddWorkItemToPerson(currMember, parameters[1]);
        }

        private string AddWorkItemToPerson(IMember currPerson, string workItemId)
        {
            IList<IWorkItem> workItems = this.InstanceFactory //TODO
               .Database
               .ListAllWorkitems();

            if (!workItems.Any(workitem => workitem.Id == int.Parse(workItemId)))
            {
                throw new ArgumentException("No workitem with this id");
            }

            IWorkItem currWorkItem = workItems
                .First(workitem => workitem.Id == int.Parse(workItemId));

            var bug = currWorkItem as IBug;
            var story = currWorkItem as IStory;

            if (bug != null)
            {
                bug.ChangeAssignee(currPerson);
            }

            if (story != null)
            {
                story.ChangeAssignee(currPerson);
            }

            currPerson.AddWorkItem(currWorkItem);

            return $"WorkItem {currWorkItem.Title} assigned to {currPerson.Name}.";
        }

        public override IList<string> GetUserInput()
        {
            IMember currPerson = ChooseMethods.ChoosePerson(this.InstanceFactory);

            IList<IWorkItem> workItems = this.InstanceFactory //TODO
                .Database
                .ListAllWorkitems();

            //lisr all workitems

            foreach (var item in workItems)
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
    }
}
