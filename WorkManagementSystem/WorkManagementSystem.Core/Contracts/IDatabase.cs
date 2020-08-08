using System.Collections.Generic;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Contracts
{
    public interface IDatabase // TODO - discuss
    {
        public IList<ITeam> Teams { get; }

        public IList<IMember> Members { get; }

        public IList<IBoard> Boards { get; }


        public IList<IBug> Bugs { get; }

        public IList<IStory> Stories { get; }

        public IList<IFeedback> Feedbacks { get; }
    }
}
