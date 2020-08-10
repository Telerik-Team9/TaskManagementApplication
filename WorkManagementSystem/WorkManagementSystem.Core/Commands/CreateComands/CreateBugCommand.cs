using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandParameters)
            : base(commandParameters) { }

        public CreateBugCommand()
            : base() { }

        public override string Execute() // Add check for ctor for Imember
        {
            this.Writer.Write("Please select a board to add a bug to: "); //List all boards
            string boardName = this.Reader.Read();

            if (!this.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException($"A board with name {boardName} does not exist in the database.");
            }

            IBoard board = this.Database
                .Boards
                .First(b => b.Name == boardName);

            this.Writer.WriteLine("Please enter the following parameters to create a bug:");

            this.Writer.Write("Title: ");
            string title = this.Reader.Read();

            this.Writer.Write("Description: ");
            string description = this.Reader.Read();

            this.Writer.Write("Priority - choose one of the following: (Medium/High/Low) or leave the field empty.");
            string priorityAsStr = this.Reader.Read();

            Priority priority;


            if (!string.IsNullOrWhiteSpace(priorityAsStr))
            {
                try
                {
                    priority = Enum.Parse<Priority>(priorityAsStr, true);
                }
                catch
                {
                    throw new InvalidEnumArgumentException("Invalid priority entered.");
                }
            }
            else
            {
                priority = Priority.Low;
            }

            this.Writer.Write("Severity - choose one of the following: (Critical/Major/Minor) or leave the field empty.");
            string severityAsStr = this.Reader.Read();

            BugSeverity severity;


            if (!string.IsNullOrWhiteSpace(severityAsStr))
            {
                try
                {
                    severity = Enum.Parse<BugSeverity>(severityAsStr, true);
                }
                catch
                {
                    throw new InvalidEnumArgumentException("Invalid severity entered.");
                }
            }
            else
            {
                severity = BugSeverity.Minor;
            }

            // status is assigned in ctor in bug

            this.Writer.WriteLine("Please enter the steps to reproduce of the bug, splliting them by '-'.");
            string stepsAsStr = this.Reader.Read();

            List<string> steps = stepsAsStr
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            IBug currentBug = this.Factory.CreateBug(title, description, priority, severity, steps);

            board.AddWorkItem(currentBug);

            this.Database.Bugs.Add(currentBug);

            return $"Bug with title '{title}' has been created.{Environment.NewLine}" + currentBug.PrintInfo();
        }
    }
}
// priority, severity, status

/*private void ParseEnums(out bool parsePriority, out Priority priority, out bool parseSeverity, out BugSeverity severity, out bool parseStatus, out BugStatus status)
{
    parsePriority = Enum.TryParse(this.CommandParameters[2], true, out priority);
    parseSeverity = Enum.TryParse(this.CommandParameters[3], true, out severity);
    parseStatus = Enum.TryParse(this.CommandParameters[4], true, out status);
}*/
/*if (this.CommandParameters.Count < 2)
            {
                return "Invalid parameters count.";
            }

            else
            {
                IBug currentBug;
                string title = this.CommandParameters[0];
                string description = this.CommandParameters[1];

                if (this.CommandParameters.Count == 2)
                {
                    currentBug = this.Factory.CreateBug(title, description);
                    this.Database.Bugs.Add(currentBug);
                }
                else
                {
                    if (this.CommandParameters.Count != 5 || this.CommandParameters.Count != 6)
                    {
                        return "Invalid parameters count.";
                    }
                    else
                    {
                        bool parsePriority, parseSeverity, parseStatus;
                        Priority priority;
                        BugSeverity severity;
                        BugStatus status;
                        ParseEnums(out parsePriority, out priority, out parseSeverity, out severity, out parseStatus, out status);

                        if (parsePriority && parseSeverity && parseStatus)
                        {
                            if (this.CommandParameters.Count == 5)
                            {
                                currentBug = this.Factory.CreateBug(title, description, priority, severity, status, null);
                            }
                            else
                            {
                                string assigneeName = this.CommandParameters[5];

                                IMember assignee = this.Database
                                    .Members
                                    .SingleOrDefault(p => p.Name == assigneeName);

                                currentBug = this.Factory.CreateBug(title, description, priority, severity, status, assignee);
                            }
                            this.Database.Bugs.Add(currentBug);
                        }
                    }
                }
                return $"Bug with title '{title}' has been created.";*/
