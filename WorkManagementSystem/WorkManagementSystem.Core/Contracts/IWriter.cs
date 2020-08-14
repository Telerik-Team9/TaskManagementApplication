namespace WorkManagementSystem.Core.Contracts
{
    public interface IWriter
    {
        public void Write(string message);
        public void WriteLine(string message);
        public void Clear();
    }
}
