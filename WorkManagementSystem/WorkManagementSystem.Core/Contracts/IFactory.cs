using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Contracts
{
    //TODO : Discuss 
    public interface IFactory
    {
        IMember CreatePerson(string name);

        IBoard CreateBoard(string boardName);

       // IBoard CreateBoardInATeam(string teamName); // invokes CreateBoard method?
        //Bug constructor overloadings - parse enums from string?
        IBug CreateBug(string title, string description);

        IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, BugStatus status);

        IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, BugStatus status, IMember assignee);
        //Story constructor overloadings - parse enums from string?
        IStory CreateStory(string title, string description);

        IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status);

        IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status, IMember assignee);
        //Feedback constructor overloadings - parse enums from string?
        IFeedback CreateFeedback(string title, string description, int rating);

        IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status);

        ITeam CreateTeam(string name);
    }
}
