using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Fakes
{
    class FakeModelsFactory : IModelsFactory
    {
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

        public IMember CreatePerson(string name)
        {
            return new Member(name);
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
