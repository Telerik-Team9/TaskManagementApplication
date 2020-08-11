﻿using System.Collections.Generic;
using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        public IReadOnlyCollection<string> StepsToReproduce { get; }

        public Priority Priority { get; }

        public BugSeverity Severity { get; }

        public BugStatus Status { get; }

        public IMember Assignee { get; }

        public void ChangePriority(Priority newPriority);

        public void ChangeSeverity(BugSeverity newSeverity);

        public void ChangeStatus(BugStatus newStatus);
    }
}
