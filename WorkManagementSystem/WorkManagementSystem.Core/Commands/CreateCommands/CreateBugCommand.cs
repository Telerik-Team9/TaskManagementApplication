using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

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
            this.Writer.WriteLine(this.ListAllBoards());
            this.Writer.WriteLine(string.Format(CoreConstants.ChooseBoardForWorkitem, "bug"));

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            IBoard board = this.InstanceFactory.Database
                .Boards
                .First(b => b.Name == boardName);

            this.Writer.WriteLine(CoreConstants.EnterFollowingParameters);

            (string title, string description) = ParseBaseWorkItemParameters();
            (Priority priority, BugSeverity severity) = this.ParseEnums();

            this.Writer.WriteLine("Please enter the steps to reproduce of the bug, splliting them by '-'.");
            string stepsAsStr = this.Reader.Read();

            List<string> steps = stepsAsStr
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            IBug currentBug = this.InstanceFactory.ModelsFactory.CreateBug(title, description, priority, severity, steps);

            board.AddWorkItem(currentBug);

            this.InstanceFactory.Database.Bugs.Add(currentBug);

            return string.Format(CoreConstants.CreatedWorkItem, "Bug")
                + Environment.NewLine
                + currentBug.PrintInfo();
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
