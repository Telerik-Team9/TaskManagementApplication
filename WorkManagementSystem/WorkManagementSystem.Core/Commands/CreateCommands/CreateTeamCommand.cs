using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

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
            this.Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "team"));

            string teamName = this.Reader.Read();

            if (this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamAlreadyExistsExcMessage, teamName));
            }

            ITeam currTeam = this.InstanceFactory.ModelsFactory.CreateTeam(teamName);
            this.InstanceFactory.Database.Teams.Add(currTeam);

            return string.Format(CoreConstants.CreatedUnit, "Team", teamName) + NewLine
                + currTeam.PrintInfo();
        }
    }
}
