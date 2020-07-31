using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models.Abstracts
{
    public abstract class Unit : IUnit
    {
        private string name;
        private IList<IWorkItem> workItems;
        private IList<IActivityHistory> activityHistory;

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
                    //TODO Fix ArgException
                }

                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "name", 5, 15));
                    //TODO Fix ArgException
                }

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

        public virtual string PrintInfo()
        {
            throw new NotImplementedException();
        }

        protected abstract string AdditionalInfo();
    }
}
