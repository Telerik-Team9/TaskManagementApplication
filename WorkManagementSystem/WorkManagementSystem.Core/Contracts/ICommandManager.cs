namespace WorkManagementSystem.Core.Contracts
{
    public interface ICommandManager
    {
        public ICommand ParseCommand(string commandLine, IInstanceFactory instanceFactory);
    }
}
