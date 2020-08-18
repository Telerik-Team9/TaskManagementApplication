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

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory.Database.Teams.First(t => t.Name == parameters[0]);
            IBoard currBoard = this.InstanceFactory.Database.Boards.First(b => b.Name == parameters[1]);

            string title = parameters[2];
            string description = parameters[3];
            (Priority priority, BugSeverity severity) = ParseEnums(parameters[4], parameters[5]);
            string stepsAsStr = parameters[6];

            return CreateBugInBoard(currBoard, title, description, priority, severity, stepsAsStr);
        }
        
        public override IList<string> GetUserInput()
        {
            (IBoard currBoard, ITeam currTeam) = ChooseMethods.ChooseBoard(this.InstanceFactory);

            (string title, string description) = ParseBaseWorkItemParameters();

            // Get Priority
            this.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Priority", "Low/Medium/High"));
            string priorityAsStr = this.Reader.Read();

            // Get Severity
            this.Writer.WriteLine(string.Format(CoreConstants.EnterEnum, "Severity", "Critical/Major/Minor"));
            string severityAsStr = this.Reader.Read();

            this.Writer.WriteLine("Enter the steps to reproduce of the bug, splliting them by '-'.");
            string stepsAsStr = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);
            parameters.Add(currBoard.Name);
            parameters.Add(title);
            parameters.Add(description);
            parameters.Add(priorityAsStr);
            parameters.Add(severityAsStr);
            parameters.Add(stepsAsStr);

            return parameters;
        }

        private string CreateBugInBoard(IBoard currBoard, string title, string description, Priority priority, BugSeverity severity, string stepsAsStr)
        {
            List<string> steps = stepsAsStr
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            IBug currBug = this.InstanceFactory.ModelsFactory.CreateBug(title, description, priority, severity, steps);

            this.InstanceFactory.Database.Bugs.Add(currBug);
            currBoard.AddWorkItem(currBug);

            return currBug.HistoryLog.First() + NewLine
                + currBug.PrintInfo();
        }

        private (Priority, BugSeverity) ParseEnums(string priorityAsStr, string severityAsStr)
        {
            // Parse Priority
            Priority priority;

            if (string.IsNullOrWhiteSpace(priorityAsStr))
            {
                priority = Priority.Low;
            }
            else if (!Enum.TryParse(priorityAsStr, true, out priority))
            {
                throw new InvalidEnumArgumentException("Invalid priority");
            }

            //Parse Severity
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
