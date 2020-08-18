using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamMembersCommand : Command
    {
        public ShowAllTeamMembersCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }
        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = GetTeamFromDatabase(parameters);
            return ShowAllTeamMembers(parameters, currTeam);
        }

        public override IList<string> GetUserInput()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                throw new ArgumentException($"There are no teams.");
            }

            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);

            return parameters;
        }

        private ITeam GetTeamFromDatabase(IList<string> parameters)
        {
            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == parameters[0]))
            {
                throw new ArgumentException($"There is no team with that name.");
            }

            ITeam currTeam = this.InstanceFactory
                .Database
                .Teams
                .First(team => team.Name == parameters[0]);
            return currTeam;
        }

        private static string ShowAllTeamMembers(IList<string> parameters, ITeam currTeam)
        {
            if (!currTeam.Members.Any())
            {
                throw new ArgumentException($"There are no members in team '{parameters[0]}'.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var member in currTeam.Members)
            {
                sb.AppendLine(member.PrintInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
