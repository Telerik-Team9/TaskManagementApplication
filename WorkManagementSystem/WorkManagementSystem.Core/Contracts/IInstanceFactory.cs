using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Core.Contracts
{
    public interface IInstanceFactory
    {
        public IDatabase Database { get; }

        public IModelsFactory ModelsFactory { get; }

        public IReader Reader { get; }

        public IWriter Writer { get; }

        public ICommandManager CommandManager { get; }
    }
}
