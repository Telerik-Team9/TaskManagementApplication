using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            var parameters = GetUserInput();

            IMember currMember = this.InstanceFactory.ModelsFactory.CreatePerson(parameters[0]);
            this.InstanceFactory.Database.Members.Add(currMember);

            string activity = string.Format(CoreConstants.CreatedMember, parameters[0]);
            currMember.AddActivityLog(activity);

            return activity
                + NewLine
                + currMember.PrintInfo();
        }

        protected override IList<string> GetUserInput()
        {
            Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "person"));

            string personName = Reader.Read();
            var userInput = new List<string>();
            userInput.Add(personName);

            if (InstanceFactory.Database.Members.Any(m => m.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberAlreadyExistsExcMessage, personName));
            }

            this.Execute(userInput);
        }
    }
}
