using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            return this.ShowAllTeams();
        }

        private string ShowAllTeams()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException("There are no teams.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var team in this.InstanceFactory.Database.Teams)
            {
                sb.AppendLine(team.PrintInfo() + NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public override IList<string> GetUserInput()
        {
            return null;
        }
    }
}
