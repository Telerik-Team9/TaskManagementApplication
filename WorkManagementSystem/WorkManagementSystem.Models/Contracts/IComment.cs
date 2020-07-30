using System.Collections.Generic;
using System.Dynamic;
using WorkManagementSystem.Models.Common;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IComment : IPrintable
    {
        public IMember Author { get; }

        public string Message { get; }
    }
}