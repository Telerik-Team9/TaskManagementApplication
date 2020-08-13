using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IInstanceFactory instanceFactory) : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
