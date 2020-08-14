namespace WorkManagementSystem.Models.Contracts
{
    public interface IBoard : IUnit
    {
        public void AddWorkItem(IWorkItem workItem);
    }
}
