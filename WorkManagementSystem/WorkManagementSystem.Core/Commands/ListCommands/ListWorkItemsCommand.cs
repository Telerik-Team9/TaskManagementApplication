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

        /*        private string ListByType(IList<string> parameters)
                {
                    return parameters[0] switch
                    {
                        "bug" => ListBugs(parameters),
                        "feedback" => ListFeedbacks(parameters),
                        "story" => ListStories(parameters),
                        "all" => ListWorkItems(parameters),

                        _ => throw new ArgumentException("Invalid workitem type.");
                    };
                }*/
        /*
                private Func<IWorkItem, bool> GetSortFilter(string sortFilter)
                {
                    return sortFilter switch
                    {
                        "yes" => w => w.Title,
                        "priority" => w => w.Pr,

                        _ => throw new ArgumentException("Wrong filter.");
                    };
                }*/
    }
}





/*        private object GetCollectionType()
        {
            return type switch
            {
                "bug" => w => w is IBug,
                "feedback" => w => w is IFeedback,
                "story" => w => w is IStory,

                _ => null
            };
        }*/




/*        private Func<IWorkItem, bool> GetPropertyFilter()
        {
            this.Writer.WriteLine("Do you want to filter by property? status/assignee or leave this empty");
            string property = this.Reader.Read();
            return null;

            this.Writer.WriteLine("Enter the value which you wish to filter");

            switch (property)
            {
                case "bug":
                    return property == "asc" ? list.OrderBy(c => c.FirstName).ToList() : list.OrderByDescending(c => c.FirstName).ToList();
                case "feedback":
                    return order == "asc" ? list.OrderBy(c => c.LastName).ToList() : list.OrderByDescending(c => c.LastName).ToList();
                case "story":
                    return order == "asc" ? list.OrderBy(c => c.Country).ToList() : list.OrderByDescending(c => c.Country).ToList();
                default:
                    throw new InvalidOperationException();
            }








        private Func<IWorkItem, bool> GetTypeFilter(string type)
{
    return type switch
    {
        "bug" => w => w is IBug,
        "feedback" => w => w is IFeedback,
        "story" => w => w is IStory,

        _ => null
    };
}
        }*/























/*private List<IOlympian> OrderList(List<IOlympian> list, string key, string order)
{
    switch (key)
    {
        case "firstname":
            return order == "asc" ? list.OrderBy(c => c.FirstName).ToList() : list.OrderByDescending(c => c.FirstName).ToList();
        case "lastname":
            return order == "asc" ? list.OrderBy(c => c.LastName).ToList() : list.OrderByDescending(c => c.LastName).ToList();
        case "country":
            return order == "asc" ? list.OrderBy(c => c.Country).ToList() : list.OrderByDescending(c => c.Country).ToList();
        default:
            throw new InvalidOperationException();
    }
}
*/
