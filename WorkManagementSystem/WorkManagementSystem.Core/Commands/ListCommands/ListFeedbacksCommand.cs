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
    public class ListFeedbacksCommand : Command
    {
        public ListFeedbacksCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var filteredCollection = this.InstanceFactory.Database.Feedbacks;

            // Filter
            if (parameters[0].ToLower() == "status")
            {
                filteredCollection = FilterByStatus(parameters, filteredCollection);
            }

            // Sort
            if (!string.IsNullOrEmpty(parameters[2]))
            {
                filteredCollection = GetSortFilter(parameters[2], filteredCollection.ToList());
            }

            return string.Join(NewLine, filteredCollection.Select(x => x.PrintInfo()));
        }

        public override IList<string> GetUserInput()
        {
            if (!this.InstanceFactory.Database.Stories.Any())
            {
                throw new ArgumentException("No stories added.");
            }

            IList<string> parameters = new List<string>();

            // Get property filter
            this.Writer.WriteLine("Do you want to filter by a property? (status)" + NewLine
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
            this.Writer.WriteLine("Do you want to sort by property? (title/rating)" + NewLine
                + "If not leave this empty");
            string sortFilter = this.Reader.Read();
            parameters.Add(sortFilter);

            return parameters;
        }

        private static IList<IFeedback> FilterByStatus(IList<string> parameters, IList<IFeedback> filteredCollection)
        {
            var status = Enum.Parse<FeedbackStatus>(parameters[1], true);
            filteredCollection = filteredCollection
                .Where(f => f.Status == status)
                .ToList();
            return filteredCollection;
        }

        private IList<IFeedback> GetSortFilter(string property, List<IFeedback> filteredCollection)
        {
            return property switch
            {
                "title" => filteredCollection.OrderBy(w => w.Title).ToList(),
                "rating" => filteredCollection.OrderBy(w => w.Rating).ToList(),

                _ => null
            };
        }

    }
}
