using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Models.Abstracts
{
    public abstract class Unit : IUnit
    {
        private string name;
        protected IList<IWorkItem> workItems;
        protected IList<IActivityHistory> activityHistory;

        protected Unit(string name)
        {
            this.Name = name;

            this.workItems = new List<IWorkItem>();
            this.activityHistory = new List<IActivityHistory>();
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "name"));
                }

                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "name", 5, 15));
                }

                ValidateForSpecialChars(value);

                this.name = value;
            }
        }

        public IReadOnlyCollection<IWorkItem> WorkItems
        {
            get
            {
                return new ReadOnlyCollection<IWorkItem>(this.workItems);
            }
        }

        public IReadOnlyCollection<IActivityHistory> ActivityHistory
        {
            get
            {
                return new ReadOnlyCollection<IActivityHistory>(this.activityHistory);
            }
        }

        public void AddActivityLog(string activity)
        {
            this.activityHistory.Add(new ActivityHistory(activity));
        }

        public virtual string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");

            // Append WorkItems
            sb.AppendLine("WorkItems:");

            if (this.WorkItems.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.WorkItems.Select(x => " -" + x.GetWorkItemType() + ": " + x.PrintInfo())));
            }
            else
            {
                sb.AppendLine(" -No workitems have been added yet.");
            }

            // Append History
            sb.AppendLine("ActivityHistory:");

            if (this.ActivityHistory.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.ActivityHistory.Select(s => " -" + s.PrintInfo())));
            }
            else
            {
                sb.AppendLine(" -No history is present yet.");
            }

            return sb.ToString().TrimEnd();
        }

        protected abstract string AdditionalInfo();

        protected void ValidateForSpecialChars(string name)
        {
            foreach (char ch in name)
            {
                if (!(char.IsLetter(ch) || char.IsWhiteSpace(ch)))
                {
                    throw new ArgumentException(GlobalConstants.InvalidUnitName, "member");
                }
            }
        }
    }
}
