using System;
using System.Collections.Generic;
using System.Linq;
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

        public override string Execute(IList<string> parameters)
        {
            IBug currBug = InstanceFactory
                .Database
                .Bugs
                .First(b => b.Id == int.Parse(parameters[0]));

            return this.AlterBug(parameters, currBug);
        }

        public override IList<string> GetUserInput()
        {
            IBug currBug = ChooseMethods.ChooseBug(this.InstanceFactory);

            this.Writer.WriteLine($"Priority: {currBug.Priority}|Severity: {currBug.Severity}|Status: {currBug.Status}\n");
            this.Writer.WriteLine("Choose which property you wish to change: (priority/severity/status)");

            string propertyToChange = this.Reader.Read();
            this.Writer.WriteLine(ValidatePropertyType(propertyToChange));

            string newValue = this.Reader.Read();
            IList<string> parameters = new List<string>();

            parameters.Add(currBug.Id.ToString());
            parameters.Add(propertyToChange);
            parameters.Add(newValue);

            return parameters;
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
        private string AlterBug(IList<string> parameters, IBug currBug)
        {
            if (Enum.TryParse(parameters[2], ignoreCase: true, out Priority priority))
            {
                currBug.ChangePriority(priority);
            }

            else if (Enum.TryParse(parameters[2], ignoreCase: true, out BugSeverity severity))
            {
                currBug.ChangeSeverity(severity);
            }

            else if (Enum.TryParse(parameters[2], ignoreCase: true, out BugStatus status))
            {
                currBug.ChangeStatus(status);
            }

            else
            {
                throw new ArgumentException("Invalid value entered.");
            }

            return $"Bug {parameters[1]} set to {parameters[2]}";
        }
    }
}


