using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateBugCommand : Command
    {
        public CreateBugCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute() // Add check for ctor for Imember
        {
            IBoard currBoard = ChooseBoard();
            return CreateBugInBoard(currBoard);
        }

        private IBoard ChooseBoard()
        {
            if (!this.InstanceFactory.Database.Boards.Any())
            {
                throw new ArgumentException("There are no boards.");
            }

            var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());

            //list teams

            this.Writer.WriteLine("Please select a team from the list above.");
            string teamName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }
            //extract team
            ITeam currTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);

            this.Writer.WriteLine(NewLine + string.Format(CoreConstants.ChooseBoardForWorkitem, "bug"));

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            //return board in a team

            IBoard teamBoard = currTeam
                .Boards
                .FirstOrDefault(b => b.Name == boardName);

            return teamBoard;
        }

        private string CreateBugInBoard(IBoard currBoard)
        {
            (string title, string description) = ParseBaseWorkItemParameters();
            (Priority priority, BugSeverity severity) = this.ParseEnums();

            this.Writer.WriteLine("Please enter the steps to reproduce of the bug, splliting them by '-'.");
            string stepsAsStr = this.Reader.Read();

            List<string> steps = stepsAsStr
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            IBug currBug = this.InstanceFactory.ModelsFactory.CreateBug(title, description, priority, severity, steps);

            this.InstanceFactory.Database.Bugs.Add(currBug);
            currBoard.AddWorkItem(currBug);

            string activity = string.Format(CoreConstants.CreatedWorkItem, "Bug", currBug.Title);
            currBug.AddHistory(activity);

            return activity + NewLine
                + currBug.PrintInfo();
        }

        private (Priority, BugSeverity) ParseEnums()
        {
            // Parse Priority
            this.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Priority", "Low/Medium/High"));
            string priorityAsStr = this.Reader.Read();
            Priority priority;

            if (string.IsNullOrWhiteSpace(priorityAsStr))
            {
                priority = Priority.Low;
            }
            else if (!Enum.TryParse(priorityAsStr, true, out priority))
            {
                throw new InvalidEnumArgumentException("Invalid priority");
            }

            // Parse Severity
            this.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Severity", "Critical/Major/Minor"));
            string severityAsStr = this.Reader.Read();
            BugSeverity severity;

            if (string.IsNullOrWhiteSpace(severityAsStr))
            {
                severity = BugSeverity.Minor;
            }
            else if (!Enum.TryParse(severityAsStr, true, out severity))
            {
                throw new Exception("Invalid severity");
            }
            return (priority, severity);
        }
    }
}
