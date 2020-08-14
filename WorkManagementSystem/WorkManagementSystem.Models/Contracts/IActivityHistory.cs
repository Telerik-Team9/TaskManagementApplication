using System;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IActivityHistory : IPrintable
    {
        public string ActivityMessage { get; }

        public DateTime ActivityTime { get; }
    }
}
