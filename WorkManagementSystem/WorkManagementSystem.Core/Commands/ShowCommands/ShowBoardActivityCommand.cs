using System.Collections.Generic;
using System.Linq;
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

        public override string Execute(IList<string> parameters)
        {
            ITeam team = this.InstanceFactory
                  .Database
                  .Teams.First(t => t.Name == parameters[0]);

            IBoard board = team
                  .Boards.First(b => b.Name == parameters[1]);

            return board.PrintActivityHistory();
        }

        public override IList<string> GetUserInput()
        {
            (IBoard board, ITeam team) = ChooseMethods.ChooseBoard(this.InstanceFactory);

            IList<string> parameters = new List<string>();
            parameters.Add(team.Name);
            parameters.Add(board.Name);

            return parameters;
        }
    }
}
