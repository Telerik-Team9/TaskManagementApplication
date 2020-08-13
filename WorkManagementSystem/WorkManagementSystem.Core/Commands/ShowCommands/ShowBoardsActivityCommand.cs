using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowBoardsActivityCommand : Command
    {
        public ShowBoardsActivityCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            IBoard board = ChooseBoard();
            return this.ReturnActivity(board);
        }

        private string ReturnActivity(IUnit board)
        {
            var sb = new StringBuilder();

            foreach (var item in board.ActivityHistory)
            {
                sb.AppendLine($"{item.ActivityMessage}|{item.ActivityTime}");
            }

            return sb.ToString().Trim();
        }
        private IBoard ChooseBoard()
        {
            this.Writer.WriteLine(this.ListAllBoards());
            this.Writer.WriteLine("\nSelect a board to see activity:");

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(board => board.Name == boardName))
            {
                throw new ArgumentException("Invalid board enterd!");
            }

            IBoard currBoard = this.InstanceFactory
                .Database
                .Boards
                .First(board => board.Name == boardName);

            return currBoard;
        }
    }
}
