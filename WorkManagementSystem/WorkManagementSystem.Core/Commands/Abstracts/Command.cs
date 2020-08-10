using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command()
        {
        }

        /*        protected Command(IList<string> commandParameters)
                {
                    this.CommandParameters = new List<string>(commandParameters); 
                }*/

        protected IList<string> CommandParameters { get; }

        protected IDatabase Database
        {
            get
            {
                return Core.Database.Instance;
            }
        }

        protected IFactory Factory
        {
            get
            {
                return Factories.Factory.Instance;
            }
        }

        protected IReader Reader
        {
            get
            {
                return Readers.ConsoleReader.Instance;
            }
        }
        protected IWriter Writer
        {
            get
            {
                return Writers.ConsoleWriter.Instance;
            }
        }

        public abstract string Execute();
    }
}