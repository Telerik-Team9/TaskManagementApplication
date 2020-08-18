using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Models
{
    public class Team : ITeam
    {
        private string name;
        private readonly IList<IMember> members;
        private readonly IList<IBoard> boards;
        private readonly IList<IActivityHistory> activityHistory;

        public Team(string name)
        {
            this.Name = name;

            this.members = new List<IMember>();
            this.boards = new List<IBoard>();

            this.activityHistory = new List<IActivityHistory>();
            activityHistory.Add(new ActivityHistory($"Team {this.Name} was created."));
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidInput, "team name"));
                }

                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidTextRange, "team name", 3, 15));
                }

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

        public IReadOnlyCollection<IActivityHistory> ActivityHistory
        {
            get
            {
                return new ReadOnlyCollection<IActivityHistory>(this.activityHistory);
            }
        }

        public string PrintInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Team name: {this.name}");
            sb.AppendLine("Members:");

            if (!this.Members.Any())
            {
                sb.AppendLine(" " + string.Format(ModelsConstants.NoUnitsInTeam, "members"));
            }
            else
            {
                sb.AppendLine(string.Join(NewLine, this.Members.Select(x => " -" + x.Name)));
            }

            sb.AppendLine("Boards:");

            if (!this.Boards.Any())
            {
                sb.AppendLine(" " + string.Format(ModelsConstants.NoUnitsInTeam, "boards"));
            }
            else
            {
                sb.AppendLine(string.Join(NewLine, this.Boards.Select(x => " -" + x.Name)));
            }

            sb.AppendLine(this.PrintActivityHistory());

            sb.AppendLine("========================================================");
            return sb.ToString().TrimEnd();
        }

        public void AddBoard(IBoard board)
        {
            if (board == null)
            {
                throw new ArgumentException(string.Format(ModelsConstants.InvalidObject, "board"));
            }

            this.boards.Add(board);

            var newActivity = new ActivityHistory($"Board with title {board.Name} was added.");
            this.activityHistory.Add(newActivity);
        }

        public void AddPerson(IMember person)
        {
            if (person == null)
            {
                throw new ArgumentException(string.Format(ModelsConstants.InvalidObject, "person"));
            }

            this.members.Add(person);

            var newActivity = new ActivityHistory($"Person with name {person.Name} was added.");
            this.activityHistory.Add(newActivity);
        }

        public string PrintActivityHistory()
        {
            var sb = new StringBuilder();

            sb.AppendLine("ActivityHistory:");
            sb.AppendLine(string.Join(NewLine, this.ActivityHistory.Select(s => " -" + s.PrintInfo())));

            return sb.ToString();
        }
    }
}
