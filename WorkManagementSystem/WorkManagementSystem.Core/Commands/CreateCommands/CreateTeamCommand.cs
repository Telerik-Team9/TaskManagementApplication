using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            /*if (this.CommandParameters.Count != 1)
            {
                return "Invalid parameters count.";
            }

            string teamName = this.CommandParameters[0];

            if (this.Database.Teams.Any(t => t.Name == teamName))
            {
                return $"Team {teamName} already exists.";
            }

            ITeam currentTeam = this.Factory.CreateTeam(teamName);
            this.Database.Teams.Add(currentTeam);

            return $"Team {teamName} has been created.";*/

            throw new NotImplementedException();
        }
    }
}
