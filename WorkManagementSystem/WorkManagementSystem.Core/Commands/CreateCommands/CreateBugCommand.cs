using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
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

        public override string Execute()
        {
            IBoard currBoard = ChooseMethods.ChooseBoard(this.InstanceFactory);
            return CreateBugInBoard(currBoard);
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

            return currBug.HistoryLog.First() + NewLine
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
