using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeDatabase : IDatabase
    {
        public IList<ITeam> Teams => new List<ITeam>();

        public IList<IMember> Members => new List<IMember>();

        public IList<IBoard> Boards => new List<IBoard>();

        public IList<IBug> Bugs => new List<IBug>() { new Bug("FakeBuuuuuuggg", "FakeBugDescription", default, default, new List<string>()) };

        public IList<IStory> Stories => new List<IStory>() { new Story("FakeStoryyyyyyyy", "FakeBugDescription", default, default, default) };

        public IList<IFeedback> Feedbacks => new List<IFeedback>() { new Feedback("FakeFeeeeeeedback", "FakeFeedbackDescription", 5, default) };

        public IList<IWorkItem> ListAllWorkitems()
        {
            IList<IWorkItem> workItems = new List<IWorkItem>();

            foreach (var bug in this.Bugs)
            {
                workItems.Add(bug);
            }

            foreach (var story in this.Stories)
            {
                workItems.Add(story);
            }

            foreach (var feedback in this.Feedbacks)
            {
                workItems.Add(feedback);
            }

            return workItems;
        }
    }
}
