﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Models
{
    public class Bug : WorkItem, IBug
    {
        private IList<string> stepsToReproduce = new List<string>();

        public Bug(string title, string description, Priority priority, BugSeverity severity, IList<string> stepsToReproduce)
            : base(title, description)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.Status = BugStatus.Active;
            this.stepsToReproduce = stepsToReproduce;
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

        public override string GetWorkItemType()
        {
            return "Bug";
        }

        protected override string AdditionalInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Priority: { this.Priority}")
                .AppendLine($"Severity: {this.Severity}")
                .AppendLine($"Status: {this.Status}")
                .AppendLine($"Steps to reproduce: ")
                .AppendLine(string.Join($"{NewLine}", this.StepsToReproduce));

            // Append Assignee
            if (this.Assignee != null)
            {
                sb.AppendLine($"Assignee: {this.Assignee.Name}");
            }
            else
            {
                sb.AppendLine("Assignee: No assignee");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
