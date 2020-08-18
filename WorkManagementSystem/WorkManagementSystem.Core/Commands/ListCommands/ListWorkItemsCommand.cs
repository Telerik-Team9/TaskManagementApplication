using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ListCommands
{
    public class ListWorkItemsCommand : Command
    {
        public ListWorkItemsCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var filteredCollection = this.InstanceFactory.Database.ListAllWorkitems();

            if (parameters[0].ToLower() == "yes")
            {
                filteredCollection = filteredCollection.OrderBy(w => w.Title).ToList();
            }

            else
            {
                filteredCollection = filteredCollection.OrderBy(w => w.Id).ToList();
            }

            return string.Join(NewLine, filteredCollection.Select(w => w.PrintInfo()));
        }

        public override IList<string> GetUserInput()
        {
            if (!this.InstanceFactory.Database.ListAllWorkitems().Any())
            {
                throw new ArgumentException("No workitems added.");
            }

            IList<string> parameters = new List<string>();

            // Get sorting filter
            this.Writer.WriteLine("Do you want to sort by title? (yes/no)");
            string sortFilter = this.Reader.Read();
            parameters.Add(sortFilter);

            return parameters;
        }
    }
}

