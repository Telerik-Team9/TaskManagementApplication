using System;
using System.Security.Cryptography;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Factories
{
    public class Factory : IFactory //TODO
    {
        private static IFactory instance;
        public static IFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Factory();
                }

                return instance;
            }
        }
        public IMember CreatePerson(string name)
        {
            return new Member(name);
        }

        public IBoard CreateBoard(string boardName)
        {
            return new Board(boardName);
        }

        public IBug CreateBug(string title, string description)
        {
            return new Bug(title, description);
        }

        public IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, BugStatus status)
        {
            return new Bug(title, description, priority, severity, status);
        }

        public IBug CreateBug(string title, string description, Priority priority, BugSeverity severity, BugStatus status, IMember assignee)
        {
            return new Bug(title, description, priority, severity, status, assignee);
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            return new Feedback(title, description, rating);
        }

        public IFeedback CreateFeedback(string title, string description, int rating, FeedbackStatus status)
        {
            return new Feedback(title, description, rating, status);
        }

        public IStory CreateStory(string title, string description)
        {
            return new Story(title, description);
        }

        public IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status)
        {
            return new Story(title, description, priority, size, status);
        }

        public IStory CreateStory(string title, string description, Priority priority, StorySize size, StoryStatus status, IMember assignee)
        {
            return new Story(title, description, priority, size, status, assignee);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
