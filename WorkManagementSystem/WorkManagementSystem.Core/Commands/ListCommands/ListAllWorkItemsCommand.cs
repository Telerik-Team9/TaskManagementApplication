using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ListCommands
{
    public class ListAllWorkItemsCommand : Command
    {
        public ListAllWorkItemsCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            this.Writer.Write("What do you want to list? all/bugs/feedbacks/stories");
            string type = this.Reader.Read();
            var filterType = GetWorkItemType(type);


            if (!this.InstanceFactory.Database.ListAllWorkitems().Any())
            {
                return "There are currently no people on the list.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var person in this.InstanceFactory.Database.Members)
            {
                sb.AppendLine(person.PrintInfo() + NewLine);
            }

            return sb.ToString().TrimEnd();

            return "";
        }

        private Func<IWorkItem, string> GetWorkItemType(string type)
            => type switch
            {
                "bugs" => b => b.
            }
    }
}
