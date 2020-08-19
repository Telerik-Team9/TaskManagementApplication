using System.Collections.Generic;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Contracts
{
    public interface IModelsFactory
    {
        IMember CreatePerson(string name);

        IBoard CreateBoard(string boardName);

        IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, IList<string> stepsToReproduce);

        IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status);

        IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status);

        ITeam CreateTeam(string name);
    }
}
