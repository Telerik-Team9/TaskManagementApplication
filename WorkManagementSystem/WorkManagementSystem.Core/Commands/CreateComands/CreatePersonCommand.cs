using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(IList<string> commandParameters)
            : base(commandParameters) { }

        public override string Execute()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Invalid parameters count");
            }

            string personName = this.CommandParameters[0];

            if (this.Database.Members.Any(m => m.Name == personName))
            {
                return $"{personName} already exists.";
            }

            IMember currentMember = this.Factory.CreatePerson(personName);
            this.Database.Members.Add(currentMember);

            return $"Member {currentMember.Name} has been created.";
        }
    }
}
