using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Common;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IActivityHistory : IPrintable
    {
        public string ActivityMessage { get; }

        public DateTime ActivityTime { get; }
    }
}
