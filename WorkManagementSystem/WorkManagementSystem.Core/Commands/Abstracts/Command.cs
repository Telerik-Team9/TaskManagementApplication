using System.Collections.Generic;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IInstanceFactory instanceFactory)
        {
            this.InstanceFactory = instanceFactory;
        }

        protected IInstanceFactory InstanceFactory { get; }

        protected (string, string) ParseBaseWorkItemParameters()
        {
            this.InstanceFactory.Writer.WriteLine(CoreConstants.EnterFollowingParameters);

            this.InstanceFactory.Writer.Write("Title: ");
            string title = this.InstanceFactory.Reader.Read();

            this.InstanceFactory.Writer.Write("Description: ");
            string description = this.InstanceFactory.Reader.Read();

            return (title, description);
        }

        public abstract string Execute();
    }
}