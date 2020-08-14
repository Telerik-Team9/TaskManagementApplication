using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IBoard board = ChooseMethods.ChooseBoard(this.InstanceFactory);
            return board.PrintActivityHistory();
        }
    }
}
