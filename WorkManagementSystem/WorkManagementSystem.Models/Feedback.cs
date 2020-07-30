using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;

        public Feedback(string title, string description) 
            : base(title, description)
        {
        }
        
        public int Rating
        {
            get
            {
                return this.rating;
            }

            private set
            {
                this.rating = (value >= 1 && value <= 10) ? 
                    value : throw new ArgumentException();
            }
        }

        public FeedbackStatus FeedbackStatus { get; }

        protected override string AdditionalInfo()
        {
            throw new NotImplementedException();
            // TODO! implement AdditionalInfo - Feedback
        }
    }
}
