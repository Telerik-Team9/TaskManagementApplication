using System.Collections.Generic;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IWorkItem : IPrintable
    {
        public int Id { get; }

        public string Title { get; }

        public string Description { get; }

        public IReadOnlyCollection<IComment> Comments { get; }

        public IReadOnlyCollection<string> HistoryLog { get; } //ActivityHistory instead of string?

        public string GetWorkItemType();

        public void AddComment(string message, IMember author);
    }
}
