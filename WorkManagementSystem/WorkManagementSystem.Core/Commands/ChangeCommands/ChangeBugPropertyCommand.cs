using System;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ChangeCommands
{
    public class ChangeBugPropertyCommand : Command
    {
        public ChangeBugPropertyCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IBug currBug = ChooseMethods.ChooseBug(this.InstanceFactory);
            return this.AlterBug(currBug);
        }

        private string AlterBug(IBug bug)
        {
            this.Writer.WriteLine($"Priority: {bug.Priority}|Severity: {bug.Severity}|Status: {bug.Status}\n");
            this.Writer.WriteLine("Choose which property you wish to change: (priority/severity/status)");

            string propertyToChange = this.Reader.Read();
            this.Writer.WriteLine(ValidatePropertyType(propertyToChange));

            string newValue = this.Reader.Read();

            if (Enum.TryParse(newValue, ignoreCase: true, out Priority priority))
            {
                bug.ChangePriority(priority);
            }

            else if (Enum.TryParse(newValue, ignoreCase: true, out BugSeverity severity))
            {
                bug.ChangeSeverity(severity);
            }

            else if (Enum.TryParse(newValue, ignoreCase: true, out BugStatus status))
            {
                bug.ChangeStatus(status);
            }

            else
            {
                throw new ArgumentException("Invalid value entered.");
            }

            return $"Bug {propertyToChange} set to {newValue}";
        }

        private string ValidatePropertyType(string value)
        {
            return value.ToLower() switch
            {
                "priority" => "(high/medium/low)",
                "severity" => "(critical/major/minor)",
                "status" => "(active/fixed)",

                _ => throw new ArgumentException("Invalid property entered!")
            };
        }
    }
}


