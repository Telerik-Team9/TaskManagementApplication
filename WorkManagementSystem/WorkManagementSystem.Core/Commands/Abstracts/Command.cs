using System.Collections.Generic;
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

        public abstract string Execute();
    }
}