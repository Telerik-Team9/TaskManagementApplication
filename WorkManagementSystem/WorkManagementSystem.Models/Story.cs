using System;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Story : WorkItem, IStory
    {
        private IMember assignee;

        public Story(string title, string description, Priority priority, StorySize size, StoryStatus status)
            : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
        }

        public Priority Priority { get; private set; } // default - notDone, if assigned - inProgress; 

        public StorySize Size { get; private set; } // 10-150 - small; 151 - 300 - medium; 301 - 500 - large; 

        public StoryStatus Status { get; private set; }

        public IMember Assignee
        {
            get
            {
                return this.assignee;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "assignee"));
                }

                this.assignee = value;
            }
        }

        public void ChangePriority(Priority newPriority)
        {
            if (this.Priority == newPriority)
            {
                throw new ArgumentException($"Priority is already on {this.Priority}.");
            }

            Priority oldPriority = this.Priority;
            this.Priority = newPriority;

            this.historyLog.Add($"Priority changed from {oldPriority} to {newPriority}.");
        }

        public void ChangeSize(StorySize newSize)
        {
            if (this.Size == newSize)
            {
                throw new ArgumentException($"Size is already on {this.Size}.");
            }

            StorySize oldSize = this.Size;
            this.Size = newSize;

            this.historyLog.Add($"Size changed from {oldSize} to {newSize}.");
        }

        public void ChangeStatus(StoryStatus newStatus)
        {
            if (this.Status == newStatus)
            {
                throw new ArgumentException($"Status is already on {this.Status}.");
            }

            StoryStatus oldStatus = this.Status;
            this.Status = newStatus;

            this.historyLog.Add($"Status changed from {oldStatus} to {newStatus}.");
        }

        public override string GetWorkItemType()
        {
            return "Story";
        }

        protected override string AdditionalInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Priority: { this.Priority}")
                .AppendLine($"Size: {this.Size}")
                .AppendLine($"Status: {this.Status}");

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
