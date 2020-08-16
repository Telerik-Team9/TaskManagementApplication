using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory
                .Database
                .Teams
                .First(t => t.Name == parameters[0]);

            return currTeam.PrintActivityHistory();
        }

        public override IList<string> GetUserInput()
        {
            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);

            return parameters;
        }
    }
}
