using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
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

        public override string Execute(IList<string> parameters)
        {
            this.CreateTeam(parameters, out ITeam currTeam);

            return string.Format(CoreConstants.CreatedUnit, "Team", parameters[0]) + NewLine
                + currTeam.PrintInfo();
        }

        public override IList<string> GetUserInput()
        {
            this.Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "team"));

            string teamName = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(teamName);

            return parameters;
        }

        private void CreateTeam(IList<string> parameters, out ITeam currTeam)
        {
            if (this.InstanceFactory.Database.Teams.Any(team => team.Name == parameters[0]))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamAlreadyExistsExcMessage, parameters[0]));
            }

            currTeam = this.InstanceFactory
                .ModelsFactory
                .CreateTeam(parameters[0]);

            this.InstanceFactory.Database.Teams.Add(currTeam);
            //  return currTeam;
        }
    }
}
