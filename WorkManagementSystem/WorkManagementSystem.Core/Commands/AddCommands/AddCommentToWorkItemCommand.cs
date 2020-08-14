using System;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.AddCommands
{
    public class AddCommentToWorkItemCommand : Command
    {
        public AddCommentToWorkItemCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IWorkItem currWorkItem = ChooseWorkItem();
            return AddCommentToWorkItem(currWorkItem);
        }

        private IWorkItem ChooseWorkItem()
        {
            this.Writer.WriteLine(ListMethods.ListAllWorkItems(this.InstanceFactory, x => "Id: " + x.Id + " | Title: " + x.Title));

            this.Writer.WriteLine(NewLine + "Please enter the workitem's id to add a comment to.");
            string id = this.Reader.Read();

            if (!this.InstanceFactory.Database.ListAllWorkitems().Any(w => w.Id == int.Parse(id)))
            {
                throw new ArgumentException("No Workitem with such Id.");
            }

            IWorkItem currWorkItem = this.InstanceFactory.Database.ListAllWorkitems()
                .First(w => w.Id == int.Parse(id));

            return currWorkItem;
        }

        private string AddCommentToWorkItem(IWorkItem currWorkItem)
        {
            this.Writer.WriteLine(string.Format("Please enter person's name:"));
            string personName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

            IMember currMember = this.InstanceFactory.Database.Members
                .First(p => p.Name == personName);

            this.Writer.WriteLine(string.Format("Enter message:"));
            string msg = this.Reader.Read();

            currWorkItem.AddComment(msg, currMember);

            return $"Message '{msg}' was added to workitem '{currWorkItem.Title}'";
        }
    }
}
