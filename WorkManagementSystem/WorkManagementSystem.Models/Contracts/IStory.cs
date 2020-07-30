using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        public Priority Priority { get; }
        public StorySize Size { get; }
        public StoryStatus StoryStatus { get; }
        public IMember assignee { get; }

    }
}
