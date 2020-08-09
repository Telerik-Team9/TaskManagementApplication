using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateStoryCommand : Command
    {
        public CreateStoryCommand(IList<string> commandParameters)
            : base(commandParameters) { }

        public CreateStoryCommand()
           : base() { }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
