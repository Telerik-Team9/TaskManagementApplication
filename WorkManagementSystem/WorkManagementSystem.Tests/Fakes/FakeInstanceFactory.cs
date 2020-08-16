using System;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeInstanceFactory : IInstanceFactory
    {
        public IDatabase Database => FakeDatabase.Instance;

        public IModelsFactory ModelsFactory => new FakeModelsFactory();

        public IReader Reader => throw new NotImplementedException();

        public IWriter Writer => throw new NotImplementedException();

        public ICommandManager CommandManager => throw new NotImplementedException();
    }
}
