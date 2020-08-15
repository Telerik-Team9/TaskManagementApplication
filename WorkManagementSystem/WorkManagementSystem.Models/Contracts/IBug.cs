using System.Collections.Generic;
using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IBug : IWorkItem, IAssignable, IPrioritizable
    {
        public IReadOnlyCollection<string> StepsToReproduce { get; }

        public BugSeverity Severity { get; }

        public BugStatus Status { get; }

        public void ChangeSeverity(BugSeverity newSeverity);

        public void ChangeStatus(BugStatus newStatus);
    }
}
