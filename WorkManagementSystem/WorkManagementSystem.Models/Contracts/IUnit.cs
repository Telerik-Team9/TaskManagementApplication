using System.Collections.Generic;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IUnit
    {
        public string Name { get; }

        public IReadOnlyCollection<IWorkItem> WorkItems { get; }

        public IReadOnlyCollection<ActivityHistory> ActivityHistory{ get; }
    }
}