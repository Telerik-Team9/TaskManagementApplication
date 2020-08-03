using System;

using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;

        public Feedback(string title, string description, int rating)
            : base(title, description)
        {
            this.Rating = rating;
            this.FeedbackStatus = FeedbackStatus.New;
        }

        public Feedback(string title, string description, int rating, FeedbackStatus status)
            : this(title, description, rating)
        {
            this.FeedbackStatus = status;
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }

            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidNumberRange, "rating", 1, 10));
                }

                this.rating = value;
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
