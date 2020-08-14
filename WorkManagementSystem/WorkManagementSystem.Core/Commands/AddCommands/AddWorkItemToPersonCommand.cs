﻿using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
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

        public override string Execute()
        {
            IMember currPerson = ChooseMethods.ChoosePerson(this.InstanceFactory);
            return AddWorkItemToPerson(currPerson);
        }

        private string AddWorkItemToPerson(IMember currPerson)
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
            int workItemId = Convert.ToInt32(this.Reader.Read());

            if (!workItems.Any(workitem => workitem.Id == workItemId))
            {
                throw new ArgumentException("No workitem with this id");
            }

            IWorkItem currWorkItem = workItems
                .First(workitem => workitem.Id == workItemId);

            currPerson.AddWorkItem(currWorkItem);
            currWorkItem.AddHistory($"Assigned to {currPerson.Name}");

            return $"WorkItem {currWorkItem.Title} assigned to {currPerson.Name}.";
        }
    }
}
