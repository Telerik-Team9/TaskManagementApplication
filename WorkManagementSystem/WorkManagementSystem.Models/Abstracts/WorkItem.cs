using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models.Abstracts
{
    public abstract class WorkItem : IWorkItem
    {
        private string title;
        private string description;

        private readonly IList<IComment> comments;
        private readonly IList<string> historyLog;

        protected WorkItem(string title, string description)
        {
            this.Id = new Guid();

            this.Title = title;
            this.Description = description;

            this.comments = new List<IComment>();
            this.historyLog = new List<string>();
        }

        public Guid Id { get; }

        public string Title
        {
            get
            {
                return this.title;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "title"));
                }

                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "title", 10, 50));
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "description"));
                }

                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "description", 10, 50));
                }

                this.description = value;
            }
        }

        public IReadOnlyCollection<IComment> Comments
        {
            get
            {
                return new ReadOnlyCollection<IComment>(this.comments);
            }
        }

        public IReadOnlyCollection<string> HistoryLog
        {
            get
            {
                return new ReadOnlyCollection<string>(this.historyLog);
            }
        }

        public virtual string PrintInfo()
        {
            throw new NotImplementedException(); // TODO PrintInfo()
        }

        protected abstract string AdditionalInfo();
    }
}
