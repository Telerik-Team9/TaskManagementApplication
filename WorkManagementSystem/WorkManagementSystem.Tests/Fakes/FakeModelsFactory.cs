using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }

        public IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, IList<string> stepsToReproduce)
        {
            throw new NotImplementedException();
        }

        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            throw new NotImplementedException();
        }

        public IMember CreatePerson(string name)
        {
            return new Member(name);
        }

        public IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name)
        {
            throw new NotImplementedException();
        }
    }
}
