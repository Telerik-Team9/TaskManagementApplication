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
        protected static int counter = 0;

        protected IList<IComment> comments;
        protected IList<string> historyLog;

        protected WorkItem(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.comments = new List<IComment>();

            this.historyLog = new List<string>();
            this.historyLog.Add($"{this.GetWorkItemType()} with title '{this.Title}' was created.");

            this.Id = counter++;
        }

        public int Id { get; }

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
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidInput, "title"));
                }

                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidTextRange, "title", 10, 50));
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
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidInput, "description"));
                }

                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidTextRange, "description", 10, 50));
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
            sb.AppendLine(this.PrintComments());
            // Append History
            sb.AppendLine(this.PrintHistory());

            sb.AppendLine("========================================================");
            return sb.ToString().TrimEnd();
        }

        private string PrintHistory()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("History:");

            if (this.HistoryLog.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.HistoryLog.Select(s => " -" + s)));
            }
            //TODO: remove the else?
            else
            {
                sb.AppendLine(" -No history is present yet.");
            }

            return sb.ToString().Trim();
        }

        private string PrintComments()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Comments:");

            if (this.Comments.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.Comments.Select(x => " -" + x.PrintInfo())));
            }
            else
            {
                sb.AppendLine(" -No comments have been added yet.");
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// Returns the addititonal information about the current Workitem.
        /// </summary>
        /// <returns>A string with the formatted additional info.</returns>
        protected abstract string AdditionalInfo();

        /// <summary>
        /// Returns the type of the WorkItem.
        /// </summary>
        /// <returns>The type of the WorkItem.</returns>
        public abstract string GetWorkItemType();

        public void AddComment(string message, IMember author)
        {
            var comment = new Comment(message, author);
            this.comments.Add(comment);

            this.historyLog.Add($"Comment from '{author.Name}' added.");
        }
    }
}












