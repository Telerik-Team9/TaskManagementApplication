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
            this.Status = status;
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
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidNumberRange, "rating", 1, 10));
                }

                this.rating = value;
            }
        }

        public override string GetWorkItemType()
        {
            return "Feedback";
        }

        public FeedbackStatus Status { get; private set; }

        protected override string AdditionalInfo()
        {
            return $"Rating: {this.Rating}{NewLine}" +
                $"Status: {this.Status}";
        }

        public void ChangeRating(int newRating)
        {
            if (this.Rating == newRating)
            {
                throw new ArgumentException(string.Format(ModelsConstants.PropertyIsAlreadyValue, "Rating", this.Rating));
            }

            int oldRating = this.Rating;
            this.Rating = newRating;
            this.historyLog.Add(string.Format(ModelsConstants.PropertyChangedFromTo, "Rating", oldRating, newRating));
        }

        public void ChangeStatus(FeedbackStatus newStatus)
        {
            if (this.Status == newStatus)
            {
                throw new ArgumentException(string.Format(ModelsConstants.PropertyIsAlreadyValue, "Status", this.Status));
            }

            FeedbackStatus oldStatus = this.Status;
            this.Status = newStatus;
            this.historyLog.Add(string.Format(ModelsConstants.PropertyChangedFromTo, "Status", oldStatus, newStatus));
        }
    }
}
