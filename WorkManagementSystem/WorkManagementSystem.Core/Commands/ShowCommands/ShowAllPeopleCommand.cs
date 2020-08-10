using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllPeopleCommand : Command
    {
/*        public ShowAllPeopleCommand(IList<string> commandParameters)
            : base(commandParameters) { }*/

        public ShowAllPeopleCommand()
           : base() { }

        public override string Execute()
        {
            if (!this.Database.Members.Any())
            {
                return "There are currently no members on the list.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var p in this.Database.Members)
            {
                sb.AppendLine("Member: " + p.Name);

                foreach (var item in p.WorkItems)
                {
                    sb.AppendLine("Workitems:");
                    sb.AppendLine(" - Item ID: " + item.Id + " | Title:" + item.Title);
                }
            }

            return sb
                .ToString()
                .Trim();
        }
    }
}
