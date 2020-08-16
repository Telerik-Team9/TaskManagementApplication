/*using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

            var filteredCollection = this.InstanceFactory.Database.ListAllWorkitems();

            if (typeFilter != null)
            {
                filteredCollection = filteredCollection.Where(typeFilter).ToList();*//* Select(propertyFilter);*//*
            }

            // Get property filter
            var propertyFilter = GetPropertyFilter(typeFilter);


            
            
            
            
            //typefileter = typeFilter ??= default









            //Get sorting filter
            //var sortFiler = 


            this.Writer.WriteLine(string.Join(NewLine, filteredCollection.Select(x => x.PrintInfo())));

            //this.Writer.Write(string.Join(NewLine, ListMethods.ListAllWorkItems(filteredCollection, x => x.PrintInfo()));




            *//*            var filterType = GetWorkItemType(type);


                        if (!this.InstanceFactory.Database.ListAllWorkitems().Any())
                        {
                            return "There are currently no people on the list.";
                        }

                        StringBuilder sb = new StringBuilder();

                        foreach (var person in this.InstanceFactory.Database.Members)
                        {
                            sb.AppendLine(person.PrintInfo() + NewLine);
                        }

                        return sb.ToString().TrimEnd();*//*

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

        private Func<IWorkItem, bool> GetPropertyFilter()
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
        }
    }
}



*//*private List<IOlympian> OrderList(List<IOlympian> list, string key, string order)
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