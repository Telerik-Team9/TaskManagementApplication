using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IList<string> commandParameters)
        {
            this.CommandParameters = new List<string>(commandParameters);
            // Factory and database - separate class? // TODO - Discuss 
        }

        protected IList<string> CommandParameters { get; }

        public abstract string Execute();
    }
}