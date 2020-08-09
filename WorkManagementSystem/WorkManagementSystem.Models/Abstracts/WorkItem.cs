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
    public abstract class WorkItem : IWorkItem
    {
        private string title;
        private string description;

        private IList<IComment> comments;
        private IList<string> historyLog;

        protected WorkItem(string title, string description)
        {
            this.Id = Guid.NewGuid();

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

        /// <summary>
        /// Returns all the information about the current Workitem.
        /// </summary>
        /// <returns>A string with the formatted info.</returns>
        public virtual string PrintInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Id: {this.Id}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Description: {this.Description}")
                .AppendLine($"{this.AdditionalInfo()}");

            // Append Comments
            sb.AppendLine("Comments:");

            if (this.Comments.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.Comments.Select(x => " -" + x.PrintInfo())));
            }
            else
            {
                sb.AppendLine(" No comments");
            }

            // Append History
            sb.AppendLine("History:");

            if (this.HistoryLog.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.HistoryLog.Select(s => " -" + s)));
            }
            else
            {
                sb.AppendLine(" No history");
            }

            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Returns the addititonal information about the current Workitem.
        /// </summary>
        /// <returns>A string with the formatted additional info.</returns>
        protected abstract string AdditionalInfo();



        // TODO: Remove AddComents and AddHistory!!! later
        public void AddComments(List<IComment> comments)
        {
            this.comments = comments;
        }

        public void AddHistory(List<string> sr)
        {
            this.historyLog = sr;
        }

    }
}












