using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Bug : WorkItem, IBug
    {
        private IList<string> stepsToReproduce;

        public Bug(string title, string description)
            : base(title, description)
        {
            this.stepsToReproduce = new List<string>();
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
