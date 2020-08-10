using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
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
            this.InstanceFactory.Writer.Write("Please select a board to add a bug to: "); //List all boards
            string boardName = this.InstanceFactory.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException($"A board with name {boardName} does not exist in the database.");
            }

            IBoard board = this.InstanceFactory.Database
                .Boards
                .First(b => b.Name == boardName);

            this.InstanceFactory.Writer.WriteLine("Please enter the following parameters to create a bug:");

            this.InstanceFactory.Writer.Write("Title: ");
            string title = this.InstanceFactory.Reader.Read();

            this.InstanceFactory.Writer.Write("Description: ");
            string description = this.InstanceFactory.Reader.Read();

            this.InstanceFactory.Writer.Write("Priority - choose one of the following: (Medium/High/Low) or leave the field empty.");
            string priorityAsStr = this.InstanceFactory.Reader.Read();

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

            this.InstanceFactory.Writer.Write("Severity - choose one of the following: (Critical/Major/Minor) or leave the field empty.");
            string severityAsStr = this.InstanceFactory.Reader.Read();

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

            this.InstanceFactory.Writer.WriteLine("Please enter the steps to reproduce of the bug, splliting them by '-'.");
            string stepsAsStr = this.InstanceFactory.Reader.Read();

            List<string> steps = stepsAsStr
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            IBug currentBug = this.InstanceFactory.ModelsFactory.CreateBug(title, description, priority, severity, steps);

            board.AddWorkItem(currentBug);

            this.InstanceFactory.Database.Bugs.Add(currentBug);

            return $"Bug with title '{title}' has been created.{Environment.NewLine}" + currentBug.PrintInfo();
        }
    }
}
