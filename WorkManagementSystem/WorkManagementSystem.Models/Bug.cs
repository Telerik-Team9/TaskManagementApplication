using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Bug : WorkItem, IBug
    {
        private readonly IList<string> stepsToReproduce;

        public Bug(string title, string description)
            : base(title, description)
        {
            this.stepsToReproduce = new List<string>();
        }

        public Bug(string title, string description, Priority priority, BugSeverity severity, BugStatus status)
            : this(title, description)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.Status = status; // default when creating - Active?
        }

        public Bug(string title, string description, Priority priority, BugSeverity severity, BugStatus status, IMember assignee)
            : this(title, description, priority, severity, status)
        {
            this.Assignee = assignee;
        }


        public IReadOnlyCollection<string> StepsToReproduce
        {
            get
            {
                return new ReadOnlyCollection<string>(this.stepsToReproduce);
            }
        }

        public Priority Priority { get; private set; }

        public BugSeverity Severity { get; private set; }

        public BugStatus Status { get; private set; }

        public IMember Assignee { get; private set; }

        public override string PrintInfo()
        {
            return base.PrintInfo();
        }

        protected override string AdditionalInfo()
        {
            throw new NotFiniteNumberException();
            // TODO!! implement AdditionalInfo - Bug
        }
    }
}
