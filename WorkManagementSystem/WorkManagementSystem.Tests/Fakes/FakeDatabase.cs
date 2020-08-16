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

        public IList<IStory> Stories => new List<IStory>();

        public IList<IFeedback> Feedbacks => new List<IFeedback>();

        public IList<IWorkItem> ListAllWorkitems()
        {
            return new List<IWorkItem>();
        }
    }
}
