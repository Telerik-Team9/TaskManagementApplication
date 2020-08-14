using System.Collections.Generic;

namespace WorkManagementSystem.Models.Contracts
{
    public interface ITeam : IPrintable
    {
        public string Name { get; }

        public IReadOnlyCollection<IMember> Members { get; }

        public IReadOnlyCollection<IBoard> Boards { get; }

        public IReadOnlyCollection<IActivityHistory> ActivityHistory { get; }

        public void AddBoard(IBoard board);

        public void AddPerson(IMember person);

        public string PrintActivityHistory();
    }
}
