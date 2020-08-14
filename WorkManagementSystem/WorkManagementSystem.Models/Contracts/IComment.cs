namespace WorkManagementSystem.Models.Contracts
{
    public interface IComment : IPrintable
    {
        public IMember Author { get; }

        public string Message { get; }
    }
}