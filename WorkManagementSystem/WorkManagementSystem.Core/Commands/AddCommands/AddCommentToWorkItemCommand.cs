using System;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

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
            IWorkItem currWorkItem = ChooseMethods.ChooseWorkItem(this.InstanceFactory);
            return AddCommentToWorkItem(currWorkItem);
        }

        private string AddCommentToWorkItem(IWorkItem currWorkItem)
        {
            this.Writer.WriteLine(string.Format("Enter person's name:"));
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
