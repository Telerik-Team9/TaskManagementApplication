using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllPeopleCommand : Command
    {
        public ShowAllPeopleCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            if (!this.InstanceFactory.Database.Members.Any())
            {
                return "There are currently no people on the list.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var person in this.InstanceFactory.Database.Members)
            {
                sb.AppendLine(person.PrintInfo() + NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}