using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Contracts;


namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeBoard : IBoard
    {
        public string Name { get => "FakeBoard"; }

        public IReadOnlyCollection<IWorkItem> WorkItems => throw new NotImplementedException();

        public IReadOnlyCollection<IActivityHistory> ActivityHistory => throw new NotImplementedException();

        public void AddActivityLog(string activity)
        {
            throw new NotImplementedException();
        }

        public void AddWorkItem(IWorkItem workItem)
        {
            throw new NotImplementedException();
        }

        public string PrintActivityHistory()
        {
            throw new NotImplementedException();
        }

        public string PrintInfo()
        {
            throw new NotImplementedException();
        }

        public string PrintWorkItems()
        {
            throw new NotImplementedException();
        }
    }
}
