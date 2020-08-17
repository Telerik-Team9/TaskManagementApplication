/*using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;

namespace WorkManagementSystem.Core.Commands.ListCommands
{
    class ListFeedbacksCommand : Command
    {
        public override string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<string> GetUserInput()
        {
            if (!this.InstanceFactory.Database.ListAllWorkitems().Any())
            {
                throw new ArgumentException("No workitems added.");
            }

            IList<string> parameters = new List<string>();

            // Get type filter
            this.Writer.WriteLine("What do you want to list? all/bug/feedback/story");
            string typeFilter = this.Reader.Read();
            parameters.Add(typeFilter);

            // Get property filter
            this.Writer.WriteLine("Do you want to filter by a property?" + NewLine
                + "If yes - enter property type the property value separated by '-'"
                + "If not leave this empty");
            string[] propertyFilter = this.Reader.Read().Split('-');
            parameters.Add(propertyFilter[0]);
            parameters.Add(propertyFilter[1]);

            // Get sorting filter
            this.Writer.WriteLine("Do you want to sort by a property?" + NewLine
                + "If yes - enter property type"
                + "If not leave this empty");
            string sortFilter = this.Reader.Read();
            parameters.Add(sortFilter);

            return parameters;
        }
    }
}
*/