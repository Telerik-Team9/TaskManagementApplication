using System.Collections.Generic;
using WorkManagementSystem.Models.Common;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IUnit : IPrintable
    {
        public string Name { get; }

        public IReadOnlyCollection<IWorkItem> WorkItems { get; }

        public IReadOnlyCollection<IActivityHistory> ActivityHistory { get; }

        public void AddActivityLog(string activity);
    }
}