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
        public Story(string title, string description, Priority priority, StorySize size, StoryStatus status)
            : base(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.Status = status;
        }

        public Priority Priority { get; private set; } // default - notDone, if assigned - inProgress; 

        public StorySize Size { get; private set; }

        public StoryStatus Status { get; private set; }

        public IMember Assignee { get; private set; }

        public void ChangePriority(Priority newPriority)
        {
            if (this.Priority == newPriority)
            {
                throw new ArgumentException(string.Format(ModelsConstants.PropertyIsAlreadyValue, "Priority", this.Priority));
            }

            Priority oldPriority = this.Priority;
            this.Priority = newPriority;

            this.historyLog.Add(string.Format(ModelsConstants.PropertyChangedFromTo, "Priority", oldPriority, newPriority));
        }

        public void ChangeSize(StorySize newSize)
        {
            if (this.Size == newSize)
            {
                throw new ArgumentException(string.Format(ModelsConstants.PropertyIsAlreadyValue, "Size", this.Size));
            }

            StorySize oldSize = this.Size;
            this.Size = newSize;

            this.historyLog.Add(string.Format(ModelsConstants.PropertyChangedFromTo, "Size",oldSize, newSize));
        }

        public void ChangeStatus(StoryStatus newStatus)
        {
            if (this.Status == newStatus)
            {
                throw new ArgumentException(string.Format(ModelsConstants.PropertyIsAlreadyValue, "Status", this.Status));
            }

            StoryStatus oldStatus = this.Status;
            this.Status = newStatus;

            this.historyLog.Add(string.Format(ModelsConstants.PropertyChangedFromTo, "Status", oldStatus, newStatus));
        }

        public void ChangeAssignee(IMember newAssignee)
        {
            if (this.Assignee == newAssignee)
            {
                throw new ArgumentException(string.Format(ModelsConstants.ObjectAlreadyAssigned, "Story", this.Assignee.Name));
            }

            this.Assignee = newAssignee;

            this.historyLog.Add(string.Format(ModelsConstants.ObjectAssignedTo, this.Assignee.Name));
        }

        public void RemoveAssignee(IMember assignee)
        {
            this.Assignee = null;
            this.historyLog.Add(string.Format(ModelsConstants.ObjectUnassignedFrom, assignee.Name));
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
