using System.Collections.Generic;
using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeDatabase : IDatabase
    {


        private static IDatabase instance = null;

        public FakeDatabase()
        {
            this.SeedFakeData();
        }

        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeDatabase();
                }

                return instance;
            }
        }

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

        public void SeedFakeData()
        {
            ITeam team9 = new Team("Team9");
            ITeam team10 = new Team("Team10");
            this.Teams.Add(team9);
            this.Teams.Add(team10);

            IBoard firstBoard = new Board("FIRSTBRD");
            IBoard secondBoard = new Board("SECONDBRD");
            team9.AddBoard(firstBoard);
            team10.AddBoard(secondBoard);
            firstBoard.AddActivityLog("A board with name 'FIRSTBRD' was added to team 'Team9'.");
            secondBoard.AddActivityLog("A board with name 'SECONDBRD' was added to team 'Team10'.");
            this.Boards.Add(firstBoard);
            this.Boards.Add(secondBoard);

            IMember maggie = new Member("Maggie");
            IMember ali = new Member("Aliii");
            maggie.AddActivityLog("A person with name 'Maggie' was created.");
            ali.AddActivityLog("A person with name 'Aliii' was created.");
            this.Members.Add(maggie);
            this.Members.Add(ali);

            IBug bug = new Bug("SeedDataBug", "SeedDataDescriptionBug", default, default, new List<string>());
            IFeedback feedback = new Feedback("SeedDataFeedback", "SeedDataDescriptionFeedback", 2, default);
            IStory story = new Story("SeedDataStory", "SeedDataDescriptionStory", default, default, default);
            firstBoard.AddWorkItem(bug);
            firstBoard.AddWorkItem(feedback);
            secondBoard.AddWorkItem(story);
            this.Bugs.Add(bug);
            this.Feedbacks.Add(feedback);
            this.Stories.Add(story);
        }
    }
}
