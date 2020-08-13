using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
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
            IBoard board = ChooseBoard();
            return board.PrintActivityHistory();
        }

        private IBoard ChooseBoard()
        {
            this.Writer.WriteLine(this.ListAllTeamBoards());
            this.Writer.WriteLine("\nSelect a team and board splitted by '-'.");

            List<string> parameters = this.Reader
                .Read()
                .Split('-')
                .ToList();

            string teamName = parameters[0];

            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException("Invalid team enterd!");
            }

            ITeam team = this.InstanceFactory.Database
                .Teams
                .First(team => team.Name == teamName);

            this.Writer.WriteLine("\nSelect a board to see activity:");

            string boardName = parameters[1];

            if (!this.InstanceFactory.Database.Boards.Any(board => board.Name == boardName))
            {
                throw new ArgumentException("Invalid board enterd!");
            }

            IBoard currBoard = this.InstanceFactory.Database
                .Boards
                .First(board => board.Name == boardName);

            return currBoard;
        }
        protected string ListAllTeamBoards()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException("No teams in database.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var team in this.InstanceFactory.Database.Teams)
            {
                sb.AppendLine(team.Name);
                foreach (var board in team.Boards)
                {
                    sb.AppendLine($"- {board.Name}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
