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
                var status = Enum.Parse<BugStatus>(parameters[1] ,true);
                filteredCollection = filteredCollection
                    .Where(b => b.Status == status)
                    .ToList();
            }

            else if (parameters[0].ToLower() == "assignee")
            {
                filteredCollection = filteredCollection
                    .Where(b => b.Assignee.Name == parameters[1])
                    .ToList();
            }

            // Sort
            if (!string.IsNullOrEmpty(parameters[2].ToLower()))
            {
                filteredCollection = filteredCollection
                    .OrderBy(GetSortFilter(parameters[2], parameters[3]))
                    .ToList();
            }

            return string.Join(NewLine, filteredCollection.Select(x => x.PrintInfo()));
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
                + "If yes - enter property type then property value separated by '-'."
                + "If not leave this empty");
            string[] sortFilter = this.Reader.Read().Split('-');

            if (sortFilter.Length == 1)
            {
                parameters.Add("");
            }

            else if (sortFilter.Length == 2)
            {
                parameters.Add(sortFilter[1]);
            }

            return parameters;
        }

        private Func<IBug, bool> GetSortFilter(string property, string value)
        {
            return property switch
            {
                "title" => w => w.Title == value,
                "priority" => w => w.Priority == Enum.Parse<Priority>(value),
                "severity" => w => w.Severity == Enum.Parse<BugSeverity>(value),

                _ => null
            };
        }
    }
}