using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
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

        public Priority Priority { get; private set; }

        public StorySize Size { get; private set; }

        public StoryStatus StoryStatus { get; private set; }

        public IMember Assignee
        {
            get
            {
                return this.assignee;
            }

            private set
            {
                this.assignee = value ?? throw new ArgumentException();
                // TODO another validation?
            }
        }

        public override string PrintInfo()
        {
            return base.PrintInfo();
        }

        protected override string AdditionalInfo()
        {
            throw new NotFiniteNumberException();
            // TODO!! implement AdditionalInfo - Story
        }
    }
}
