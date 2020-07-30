using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IActivityHistory
    {
        public string ActivityMessage { get; }

        public DateTime ActivityTime { get; }
    }
}
