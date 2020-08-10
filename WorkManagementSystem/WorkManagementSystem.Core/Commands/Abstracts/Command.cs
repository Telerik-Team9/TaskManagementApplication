using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected Command(IInstanceFactory instanceFactory)
        {
            this.InstanceFactory = instanceFactory;
        }

        protected IInstanceFactory InstanceFactory { get; }

        protected (string, string) ParseBaseWorkItemParameters()
        {
            this.InstanceFactory.Writer.Write("Title: ");
            string title = this.InstanceFactory.Reader.Read();

            this.InstanceFactory.Writer.Write("Description: ");
            string description = this.InstanceFactory.Reader.Read();

            return (title, description);
        }
        protected string ListAllBoards()
        {
            if (!this.InstanceFactory.Database.Boards.Any())
            {
                throw new ArgumentException(CoreConstants.NoBoardsForWorkitemsExcMessage);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var board in this.InstanceFactory.Database.Boards)
            {
                sb.AppendLine(board.Name);
            }

            return sb.ToString().Trim();
        }

        public abstract string Execute();
    }
}