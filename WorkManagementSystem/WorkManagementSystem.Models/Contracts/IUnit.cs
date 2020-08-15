using System.Collections.Generic;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IUnit : IPrintable
    {
        public string Name { get; }

        public IReadOnlyCollection<IWorkItem> WorkItems { get; }

        public IReadOnlyCollection<IActivityHistory> ActivityHistory { get; }

        public void AddActivityLog(string activity);

        public void AddWorkItem(IWorkItem workItem);

        public string PrintWorkItems();

        public string PrintActivityHistory();
    }
}