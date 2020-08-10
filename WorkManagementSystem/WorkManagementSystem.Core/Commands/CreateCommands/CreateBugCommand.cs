using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateBugCommand : Command
    {
/*        public CreateBugCommand(IList<string> commandParameters)
            : base(commandParameters) { }*/

        public CreateBugCommand()
            : base() { }

        public override string Execute() // Add check for ctor for Imember
        {
            if (this.CommandParameters.Count < 2)
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
                return $"Bug with title '{title}' has been created.";
            }
        }

        private void ParseEnums(out bool parsePriority, out Priority priority, out bool parseSeverity, out BugSeverity severity, out bool parseStatus, out BugStatus status)
        {
            parsePriority = Enum.TryParse(this.CommandParameters[2], true, out priority);
            parseSeverity = Enum.TryParse(this.CommandParameters[3], true, out severity);
            parseStatus = Enum.TryParse(this.CommandParameters[4], true, out status);
        }
    }
}
