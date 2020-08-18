using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ListCommands
{
    public class ListBugsCommand : Command
    {
        public ListBugsCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var filteredCollection = this.InstanceFactory.Database.Bugs;

            // Filter
            if (parameters[0].ToLower() == "status")
            {
                filteredCollection = FilterByStatus(parameters, filteredCollection);
            }

            else if (parameters[0].ToLower() == "assignee")
            {
                filteredCollection = FilterByAssignee(parameters, filteredCollection);
            }

            // Sort
            if (!string.IsNullOrEmpty(parameters[2]))
            {
                filteredCollection = GetSortFilter(parameters[2], filteredCollection.ToList());
            }

            return string.Join(NewLine, filteredCollection.Select(x => x.PrintInfo()));
        }

        private static IList<IBug> FilterByStatus(IList<string> parameters, IList<IBug> filteredCollection)
        {
            var status = Enum.Parse<BugStatus>(parameters[1], true);
            filteredCollection = filteredCollection
                .Where(b => b.Status == status)
                .ToList();
            return filteredCollection;
        }

        private IList<IBug> FilterByAssignee(IList<string> parameters, IList<IBug> filteredCollection)
        {
            if (!this.InstanceFactory.Database.Members.Any(m => m.Name == parameters[1]))
                throw new ArgumentException("No member with that name.");

            if (!this.InstanceFactory.Database.Members.First(m => m.Name == parameters[1]).WorkItems.Any())
                throw new ArgumentException("This member has no assined workitems yet.");

            filteredCollection = filteredCollection
                .Where(b => b.Assignee != null && b.Assignee.Name == parameters[1])
                .ToList();
            return filteredCollection;
        }

        public override IList<string> GetUserInput()
        {
            if (!this.InstanceFactory.Database.Bugs.Any())
            {
                throw new ArgumentException("No bugs added.");
            }

            IList<string> parameters = new List<string>();

            // Get property filter
            this.Writer.WriteLine("Do you want to filter by a property? (status/assignee)" + NewLine
                + "If yes - enter property type then property value separated by '-'."
                + "If not leave this empty");
            string[] propertyFilter = this.Reader.Read().Split('-');
            parameters.Add(propertyFilter[0]);

            if (propertyFilter.Length == 1)
            {
                parameters.Add("");
            }

            else if (propertyFilter.Length == 2)
            {
                parameters.Add(propertyFilter[1]);
            }

            // Get sorting filter
            this.Writer.WriteLine("Do you want to sort by property? (title/priority/severity)" + NewLine
                + "If not leave this empty");
            string sortFilter = this.Reader.Read();
            parameters.Add(sortFilter);

            return parameters;
        }

        private IList<IBug> GetSortFilter(string property, List<IBug> filteredCollection)
        {
            return property switch
            {
                "title" => filteredCollection.OrderBy(w => w.Title).ToList(),
                "priority" => filteredCollection.OrderBy(w => w.Priority).ToList(),
                "severity" => filteredCollection.OrderBy(w => w.Severity).ToList(),

                _ => null
            };
        }
    }
}