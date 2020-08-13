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
            this.Writer.WriteLine(this.ListAllBoards());
            this.Writer.WriteLine("\nSelect a board to see activity:");

            string boardName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Boards.Any(board => board.Name == boardName))
            {
                throw new ArgumentException("Invalid board enterd!");
            }

            IBoard currBoard = this.InstanceFactory.Database
                .Boards
                .First(board => board.Name == boardName);

            return currBoard;
        }
    }
}
