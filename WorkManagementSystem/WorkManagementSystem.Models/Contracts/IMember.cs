namespace WorkManagementSystem.Models.Contracts
{
    public interface IMember : IUnit
    {
        public void RemoveWorkItem(IWorkItem currWorkItem);
    }
}
