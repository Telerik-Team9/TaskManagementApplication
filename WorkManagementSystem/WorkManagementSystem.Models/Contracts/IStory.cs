using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IStory : IWorkItem, IAssignable, IPrioritizable
    {
        public StorySize Size { get; }

        public StoryStatus Status { get; }

        public void ChangeSize(StorySize newSize);

        public void ChangeStatus(StoryStatus newStatus);
    }
}
