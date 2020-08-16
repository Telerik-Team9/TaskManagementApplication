using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeInstanceFactory : IInstanceFactory
    {
        public IDatabase Database => new FakeDatabase();

        public IModelsFactory ModelsFactory => throw new NotImplementedException();

        public IReader Reader => throw new NotImplementedException();

        public IWriter Writer => throw new NotImplementedException();

        public ICommandManager CommandManager => throw new NotImplementedException();
    }
}
