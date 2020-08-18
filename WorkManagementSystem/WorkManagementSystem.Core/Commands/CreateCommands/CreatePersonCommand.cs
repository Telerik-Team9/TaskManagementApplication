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

        public override string Execute(IList<string> parameters)
        {           
            this.CreatePerson(parameters, out IMember currMember, out string activity);

            return activity
                + NewLine
                + currMember.PrintInfo();
        }

        public override IList<string> GetUserInput()
        {
            this.Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "person"));

            string personName = this.Reader.Read();

            
            IList<string> parameters = new List<string>();
            parameters.Add(personName);

            return parameters;
        }

        private void CreatePerson(IList<string> parameters, out IMember currMember, out string activity)
        {
            if (InstanceFactory.Database.Members.Any(m => m.Name == parameters[0]))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberAlreadyExistsExcMessage, parameters[0]));
            }

            currMember = this.InstanceFactory
                .ModelsFactory
                .CreatePerson(parameters[0]);

            this.InstanceFactory.Database.Members.Add(currMember);

            activity = string.Format(CoreConstants.CreatedMember, parameters[0]);
            currMember.AddActivityLog(activity);
        }
    }
}
