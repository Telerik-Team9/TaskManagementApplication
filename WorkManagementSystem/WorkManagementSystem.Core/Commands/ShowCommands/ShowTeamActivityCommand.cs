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

        public override string Execute()
        {
            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);
            return currTeam.PrintActivityHistory();
        }
    }
}
