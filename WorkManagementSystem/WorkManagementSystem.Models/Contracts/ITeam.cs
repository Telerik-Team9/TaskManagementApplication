using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Common;

namespace WorkManagementSystem.Models.Contracts
{
    public interface ITeam : IPrintable
    {
        public string Name { get; }
        public IReadOnlyCollection<IMember> Members { get; }
        public IReadOnlyCollection<IBoard> Boards { get; }
        public void AddBoard(IBoard board);
        public void AddPerson(IMember person);
    }
}
