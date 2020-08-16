using System.Collections.Generic;

namespace WorkManagementSystem.Core.Contracts
{
    public interface ICommand
    {
        public IList<string> GetUserInput();
        public string Execute(IList<string> parameters);
    }
}
