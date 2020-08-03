using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Team : ITeam
    {
        private string name;
        private readonly IList<IMember> members;
        private readonly IList<IBoard> boards;

        public Team(string name)
        {
            this.Name = name;

            this.members = new List<IMember>();
            this.boards = new List<IBoard>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "team name", 3, 15));
                }

                ValidateForSpecialChars(value);

                this.name = value;
            }
        }

        public IReadOnlyCollection<IMember> Members
        {
            get
            {
                return new ReadOnlyCollection<IMember>(this.members);
            }
        }

        public IReadOnlyCollection<IBoard> Boards
        {
            get
            {
                return new ReadOnlyCollection<IBoard>(this.boards);
            }
        }

        public string PrintInfo()
        {
            throw new NotImplementedException();
        }
        private void ValidateForSpecialChars(string name) // remove
        {
            foreach (char ch in name)
            {
                if (!(char.IsLetter(ch) || char.IsWhiteSpace(ch)))
                {
                    throw new ArgumentException(GlobalConstants.InvalidUnitName);
                }
            }
        }
    }
}
