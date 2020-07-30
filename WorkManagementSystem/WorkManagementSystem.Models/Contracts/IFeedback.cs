using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IFeedback
    {
        int Rating { get; }
        public FeedbackStatus FeedbackStatus { get; }
    }
}
