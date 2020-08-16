using System;
using System.Collections.Generic;
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

        public override string Execute(IList<string> parameters)
        {
            IWorkItem item = this.InstanceFactory
                .Database
                .ListAllWorkitems()
                .First(x=>x.Id == int.Parse(parameters[0]));

            IMember currMember = this.InstanceFactory.Database.Members
                .First(p => p.Name == parameters[1]);

            item.AddComment(parameters[2], currMember);

            return $"Message '{parameters[2]}' was added to workitem '{item.Title}'";
        }

        public override IList<string> GetUserInput()
        {
            IWorkItem currWorkItem = ChooseMethods.ChooseWorkItem(this.InstanceFactory);

            this.Writer.WriteLine(string.Format("Enter person's name:"));
            string personName = this.Reader.Read();


            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

            this.Writer.WriteLine(string.Format("Enter message:"));
            string msg = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currWorkItem.Id.ToString());
            parameters.Add(personName);
            parameters.Add(msg);

            return parameters;
        }
    }
}
