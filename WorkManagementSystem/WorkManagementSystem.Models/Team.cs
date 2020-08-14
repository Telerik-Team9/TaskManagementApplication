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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "team name"));
                }

                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "team name", 3, 15));
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
                sb.AppendLine(" No members in the team.");
            }
            else
            {
                sb.AppendLine(string.Join(NewLine, this.Members.Select(x => " -" + x.Name)));
            }

            sb.AppendLine("Boards:");

            if (!this.Boards.Any())
            {
                sb.AppendLine(" No boards in the team.");
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
                throw new ArgumentException("The board you tried to enter is invalid.");
            }

            this.boards.Add(board);

            var newActivity = new ActivityHistory($"Board with title {board.Name} was added.");
            this.activityHistory.Add(newActivity);
        }

        public void AddPerson(IMember person)
        {
            if (person == null)
            {
                throw new ArgumentException("The person you tried to enter is invalid.");
            }

            this.members.Add(person);

            var newActivity = new ActivityHistory($"Person with name {person.Name} was added.");
            this.activityHistory.Add(newActivity);
        }

        public string PrintActivityHistory()
        {
            var sb = new StringBuilder();

            sb.AppendLine("ActivityHistory:");

            if (this.ActivityHistory.Any())
            {
                sb.AppendLine(string.Join(NewLine, this.ActivityHistory.Select(s => " -" + s.PrintInfo())));
            }
            else
            {
                sb.AppendLine(" -No history is present yet.");
            }

            return sb.ToString();
        }
    }
}
