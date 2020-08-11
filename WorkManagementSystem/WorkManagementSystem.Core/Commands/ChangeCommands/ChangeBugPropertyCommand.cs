using System;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ChangeCommands
{
    public class ChangeBugPropertyCommand : Command
    {
        public ChangeBugPropertyCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IBug currBug = this.ChooseBug();
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

        private IBug ChooseBug()
        {
            this.Writer.WriteLine(this.ListAllBugs());

            this.Writer.Write("Please type in the ID of the bug you want to change: ");
            string idAsStr = this.Reader.Read();

            if (!this.InstanceFactory.Database.Bugs.Any(b => b.Id == int.Parse(idAsStr)))
            {
                throw new ArgumentException("You have entered wrong ID.");
            }

            IBug currBug = this.InstanceFactory
                .Database
                .Bugs
                .First(b => b.Id == int.Parse(idAsStr));

            return currBug;
        }

        private string ListAllBugs()
        {
            if (!this.InstanceFactory.Database.Bugs.Any())
            {
                throw new ArgumentException("There are no bugs.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var bug in this.InstanceFactory.Database.Bugs)
            {
                sb.AppendLine($"ID: {bug.Id}|Title: {bug.Title}|Priority: {bug.Priority}|Severity: {bug.Severity}|Status: {bug.Status}");
            }
            sb.AppendLine("+++++++++++++++++++++++++++++");

            return sb.ToString().TrimEnd();
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

        //private T GetEnumFromString<T>(string value)
        //    where T : struct, IConvertible
        //{
        //    if (!typeof(T).IsEnum)
        //    {
        //        throw new ArgumentException("Invalid property entered.");
        //    }

        //    T result = Enum.Parse<T>(value, ignoreCase: true);

        //    return result;
        //} // for refactoring
    }
}


