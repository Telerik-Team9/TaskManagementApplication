using System;

using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Story : WorkItem, IStory
    {
        private IMember assignee;

        public Story(string title, string description)
            : base(title, description)
        {
        }

        public Story(string title, string description, Priority priority, StorySize size, StoryStatus status)
            : this(title, description)
        {
            this.Priority = priority;
            this.Size = size;
            this.StoryStatus = status; // remove parameter from ctor and assign default value - notDone, 
        }

        public Story(string title, string description, Priority priority, StorySize size, StoryStatus status, IMember assignee)
            : this(title, description, priority, size, status)
        {
            this.Assignee = assignee;
        }

        public Priority Priority { get; private set; } // default - notDone, if assigned - inProgress; 

        public StorySize Size { get; private set; } // 10-150 - small; 151 - 300 - medium; 301 - 500 - large; 

        public StoryStatus StoryStatus { get; private set; } 

        public IMember Assignee
        {
            get
            {
                return this.assignee;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "assignee"));
                }

                this.assignee = value;
            }
        }

        protected override string AdditionalInfo()
        {
            throw new NotFiniteNumberException();
            // TODO!! implement AdditionalInfo - Story
        }
    }
}
