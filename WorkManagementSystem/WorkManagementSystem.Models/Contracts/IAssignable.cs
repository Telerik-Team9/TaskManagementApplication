using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IAssignable
    {
        public IMember Assignee { get; }

        public void ChangeAssignee(IMember newAssignee);
    }
}
