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

        public IReader Reader { get => this.InstanceFactory.Reader; }

        public IWriter Writer { get => this.InstanceFactory.Writer; }

        protected (string, string) ParseBaseWorkItemParameters()
        {
            this.Writer.Write("Title: ");
            string title = this.Reader.Read();

            this.Writer.Write("Description: ");
            string description = this.Reader.Read();

            return (title, description);
        }

        public abstract string Execute();
    }
}