using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        int Rating { get; }

        public FeedbackStatus FeedbackStatus { get; }
    }
}
