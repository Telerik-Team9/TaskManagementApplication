using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Factories
{
    public class ModelsFactory : IModelsFactory //TODO
    {
        public IMember CreatePerson(string name)
        {
            return new Member(name);
        }

        public IBoard CreateBoard(string boardName)
        {
            return new Board(boardName);
        }

        public IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, IList<string> stepsToReproduce)
        {
            return new Bug(title, description, priority, severity, stepsToReproduce);
        }

        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            return new Feedback(title, description, rating, status);
        }

        public IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status)
        {
            return new Story(title, description, priority, size, status);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
