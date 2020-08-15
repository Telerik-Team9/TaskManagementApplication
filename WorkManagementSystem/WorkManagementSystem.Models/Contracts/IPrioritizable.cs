using WorkManagementSystem.Models.Common.Enums;

namespace WorkManagementSystem.Models.Contracts
{
    public interface IPrioritizable
    {
        public Priority Priority { get; }

        public void ChangePriority(Priority newPriority);
    }
}
