using System;
using System.Linq;
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
            if (!this.InstanceFactory.Database.ListAllWorkitems().Any())
            {
                return "No workitems added.";
            }

            // Get type filter
            var typeFilter = GetTypeFilter();

            // Get property filter
            //var propertyFilter = GetPropertyFilter();

            //Get sorting filter
            //var sortFiler = 

            var filteredCollection = this.InstanceFactory.Database.ListAllWorkitems();
            filteredCollection = filteredCollection.Where(typeFilter).ToList();/* Select(propertyFilter);*/

            this.Writer.WriteLine(string.Join(NewLine, filteredCollection.Select(x => x.PrintInfo())));

            //this.Writer.Write(string.Join(NewLine, ListMethods.ListAllWorkItems(filteredCollection, x => x.PrintInfo()));




            /*            var filterType = GetWorkItemType(type);


                        if (!this.InstanceFactory.Database.ListAllWorkitems().Any())
                        {
                            return "There are currently no people on the list.";
                        }

                        StringBuilder sb = new StringBuilder();

                        foreach (var person in this.InstanceFactory.Database.Members)
                        {
                            sb.AppendLine(person.PrintInfo() + NewLine);
                        }

                        return sb.ToString().TrimEnd();*/

            return "";
        }

        private Func<IWorkItem, bool> GetTypeFilter()
        {
            this.Writer.Write("What do you want to list? all/bug/feedback/story");
            string type = this.Reader.Read();

            return type switch
            {
                "bug" => w => w is IBug,
                "feedback" => w => w is IFeedback,
                "story" => w => w is IStory,

                _ => null
            };
        }

        /*        private Func<IWorkItem, bool> GetPropertyFilter()
                {
                    this.Writer.Write("Do you want to filter by property? all/bug/feedback/story");
                    string property = this.Reader.Read();

                    return property switch
                    {
                        "bug" => w => w is IBug,
                        "feedback" => w => w is IFeedback,
                        "story" => w => w is IStory,

                        _ => null
                    };
                }*/
    }
}
