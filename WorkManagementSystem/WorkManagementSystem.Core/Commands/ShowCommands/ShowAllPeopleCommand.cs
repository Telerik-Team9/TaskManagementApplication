using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllPeopleCommand : Command
    {
        public ShowAllPeopleCommand(IList<string> commandParameters)
            : base(commandParameters) { }

        public ShowAllPeopleCommand()
           : base() { }

        public override string Execute()
        {
            if (!this.Database.Members.Any())
            {
                return "There are currently no people on the list.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var p in this.Database.Members)
            {
                sb.AppendLine(p.PrintInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}