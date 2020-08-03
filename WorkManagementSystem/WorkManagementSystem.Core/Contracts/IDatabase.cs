using System.Collections.Generic;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Contracts
{
    public interface IDatabase // TODO - discuss
    {
        public IList<ITeam> Teams { get; }

        public IList<IMember> Members { get; }

        public IList<IBoard> Boards { get; }

        public IList<IWorkItem> WorkItems { get; }
    }
}
