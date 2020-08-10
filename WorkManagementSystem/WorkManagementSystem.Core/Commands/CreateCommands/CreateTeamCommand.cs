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
            /*this.InstanceFactory.Writer.WriteLine(CoreConstants.EnterFollowingParameters);

            (string title, string description) = ParseBaseWorkItemParameters();
            (Priority priority, StorySize size, StoryStatus status) = ParseEnums();

            var currStory = this.InstanceFactory.ModelsFactory.CreateStory(title, description, priority, size, status);

            this.InstanceFactory.Database.Stories.Add(currStory);

            return string.Format(CoreConstants.CreatedWorkItem, "Story", currStory.Title)
                + NewLine + currStory.PrintInfo();*/
            throw new NotImplementedException();
        }
    }
}
