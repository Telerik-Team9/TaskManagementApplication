using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamBoardsCommand : Command
    {
        public ShowAllTeamBoardsCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory
                .Database
                .Teams
                .First(t => t.Name == parameters[0]);

            return ShowAllTeamBoards(currTeam);
        }

        public override IList<string> GetUserInput()
        {
            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);

            return parameters;
        }

        private string ShowAllTeamBoards(ITeam currTeam)
        {
            if (!currTeam.Boards.Any())
            {
                throw new ArgumentException($"There are no boards in team '{currTeam.Name}'.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var board in currTeam.Boards)
            {
                sb.AppendLine(board.PrintInfo() + NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
