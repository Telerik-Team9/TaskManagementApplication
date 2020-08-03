using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Common;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IWorkItem : IPrintable
    {
        public Guid Id { get; }

        public string Title { get; }

        public string Description { get; }

        public IReadOnlyCollection<IComment> Comments { get; }

        public IReadOnlyCollection<string> HistoryLog { get; } //ActivityHistory instead of string?
    }
}
