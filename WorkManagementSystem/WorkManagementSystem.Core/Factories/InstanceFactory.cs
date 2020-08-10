using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Readers;
using WorkManagementSystem.Core.Writers;

namespace WorkManagementSystem.Core.Factories
{
    public class InstanceFactory : IInstanceFactory
    {
        public InstanceFactory()
        {
            this.Database = new Database();
            this.ModelsFactory = new ModelsFactory();
            this.CommandManager = new CommandManager();
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
        }

        public IDatabase Database { get; }

        public IModelsFactory ModelsFactory { get; }

        public ICommandManager CommandManager { get; }

        public IReader Reader { get; }

        public IWriter Writer { get; }
    }
}
