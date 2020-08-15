using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.Fakes
{
    public class FakeMember : IMember
    {
        public string Name { get => "FakeMember"; }

        public IReadOnlyCollection<IWorkItem> WorkItems => throw new NotImplementedException();

        public IReadOnlyCollection<IActivityHistory> ActivityHistory => throw new NotImplementedException();

        public void AddActivityLog(string activity)
        {
            throw new NotImplementedException();
        }

        public void AddWorkItem(IWorkItem currWorkItem)
        {
            throw new NotImplementedException();
        }

        public string PrintActivityHistory()
        {
            throw new NotImplementedException();
        }

        public string PrintInfo()
        {
            return "This is FakeMember";
        }

        public string PrintWorkItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveWorkItem(IWorkItem currWorkItem)
        {
            throw new NotImplementedException();
        }
    }
}
