using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IMember : IUnit
    {
        public void AddWorkItem(IWorkItem currWorkItem);
    }
}
