using System;

using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Models
{
    public class Feedback : WorkItem, IFeedback
    {
        private int rating;

        public Feedback(string title, string description, int rating, FeedbackStatus status)
            : base(title, description)
        {
            this.Rating = rating;
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

        public override string GetWorkItemType()
        {
            return "Feedback";
        }

        public FeedbackStatus FeedbackStatus { get; private set; }

        protected override string AdditionalInfo()
        {
            return $"Rating: {this.Rating}{NewLine}" +
                $"Status: {this.FeedbackStatus}";
        }

        public void ChangeRating(int newRating)
        {
            if (this.Rating == newRating)
            {
                throw new ArgumentException($"Rating is already {this.Rating}");
            }

            int oldRating = this.Rating;
            this.Rating = newRating;
            this.historyLog.Add($"Rating changed from {oldRating} to {newRating}.");
        }

        public void ChangeStatus(FeedbackStatus newStatus)
        {
            if (this.FeedbackStatus == newStatus)
            {
                throw new ArgumentException($"Status is already {this.FeedbackStatus}");
            }

            FeedbackStatus oldStatus = this.FeedbackStatus;
            this.FeedbackStatus = newStatus;
            this.historyLog.Add($"Rating changed from {oldStatus} to {newStatus}.");
        }
    }
}
