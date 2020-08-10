using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Core.Contracts
{
    public interface ICommandManager
    {
        public ICommand ParseCommand(string commandLine, IInstanceFactory instanceFactory);
    }
}
