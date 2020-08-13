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

        public IReader Reader { get => this.InstanceFactory.Reader; }

        public IWriter Writer { get => this.InstanceFactory.Writer; }

        protected (string, string) ParseBaseWorkItemParameters()
        {
            this.Writer.Write("Title: ");
            string title = this.Reader.Read();

            this.Writer.Write("Description: ");
            string description = this.Reader.Read();

            return (title, description);
        }

        protected string ListAllTeams()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException("No teams in database.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var team in this.InstanceFactory.Database.Teams)
            {
                sb.AppendLine(team.Name);
            }

            return sb.ToString().Trim();
        }

        protected string ListAllBoards()
        {
            if (!this.InstanceFactory.Database.Boards.Any())
            {
                throw new ArgumentException("No boards in database.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var board in this.InstanceFactory.Database.Boards)
            {
                sb.AppendLine(board.Name);
            }

            return sb.ToString().Trim();
        }

        protected string ListAllMembers()
        {
            if (!this.InstanceFactory.Database.Members.Any())
            {
                throw new ArgumentException("No members in database.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var member in this.InstanceFactory.Database.Members)
            {
                sb.AppendLine(member.Name);
            }

            return sb.ToString().Trim();
        }

        protected string ListAllWorkItems()
        {
            var workitems = this.InstanceFactory.Database.ListAllWorkitems();

            if (!workitems.Any())
            {
                throw new ArgumentException("No workitems in database.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var workitem in workitems)
            {
                sb.AppendLine($"{workitem.GetWorkItemType()}: Id: {workitem.Id}|Title: {workitem.Title}");
            }

            return sb.ToString().Trim();
        }

        public abstract string Execute();
    }
}