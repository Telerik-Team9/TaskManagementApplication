using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowPersonActivityCommand : Command
    {
        public ShowPersonActivityCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IMember member = ChooseMethods.ChoosePerson(this.InstanceFactory);
            return member.PrintActivityHistory();
        }
    }
}
