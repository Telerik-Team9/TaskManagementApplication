using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models.Abstracts
{
    public abstract class Unit : IUnit
    {
        private string name;
        private IList<IWorkItem> workItems;
        private IList<ActivityHistory> activityHistory;

        protected Unit(string name)
        {
            this.Name = name;

            this.workItems = new List<IWorkItem>();
            this.activityHistory = new List<ActivityHistory>();
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
                    throw new ArgumentException();
                    //TODO Fix ArgException
                }

                if (value.Length < 5 || value.Length > 15)
                {
                    throw new ArgumentException();
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

        public IReadOnlyCollection<ActivityHistory> ActivityHistory
        {
            get
            {
                return new ReadOnlyCollection<ActivityHistory>(this.activityHistory);
                // TODO Swap with interface
            }
        }

        public string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
