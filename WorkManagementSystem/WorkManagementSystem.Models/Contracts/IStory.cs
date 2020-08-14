using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        public Priority Priority { get; }

        public StorySize Size { get; }

        public StoryStatus Status { get; }

        public IMember Assignee { get; }

        public void ChangePriority(Priority newPriority);

        public void ChangeSize(StorySize newSize);

        public void ChangeStatus(StoryStatus newStatus);
    }
}
