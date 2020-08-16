using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowPersonActivityCommand : Command
    {
        public ShowPersonActivityCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            IMember member = InstanceFactory
                .Database
                .Members
                .First(b => b.Name == parameters[0]);

            return member.PrintActivityHistory();
        }

        public override IList<string> GetUserInput()
        {
            IMember member = ChooseMethods.ChoosePerson(this.InstanceFactory);

            IList<string> parameters = new List<string>();
            parameters.Add(member.Name);

            return parameters;
        }
    }
}
