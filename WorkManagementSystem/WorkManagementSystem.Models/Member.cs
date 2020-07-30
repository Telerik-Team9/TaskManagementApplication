using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Member : Unit, IMember
    {
        public Member(string name) 
            : base(name)
        {
        }

        // TODO implement
        public string Name => throw new NotImplementedException();

        public IReadOnlyCollection<IWorkItem> WorkItems => throw new NotImplementedException();

        public IReadOnlyCollection<ActivityHistory> ActivityHistory => throw new NotImplementedException();

        public string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
