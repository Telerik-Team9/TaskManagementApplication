using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeDatabase : IDatabase
    {
        public IList<ITeam> Teams => new List<ITeam>();

        public IList<IMember> Members => new List<IMember>();

        public IList<IBoard> Boards => new List<IBoard>();

        public IList<IBug> Bugs => new List<IBug>();

        public IList<IStory> Stories => new List<IStory>();// { new Story("FakeStoryyyyyyyy", "FakeBugDescription", default, default, default) };

        public IList<IFeedback> Feedbacks => new List<IFeedback>(); //{ new Feedback("FakeFeeeeeeedback", "FakeFeedbackDescription", 5, default) };

        public IList<IWorkItem> ListAllWorkitems()
        {
            return new List<IWorkItem>();
        }
    }
}
