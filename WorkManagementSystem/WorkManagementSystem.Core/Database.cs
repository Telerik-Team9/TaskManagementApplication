using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core
{
    public class Database : IDatabase
    {
        private readonly List<ITeam> teams = new List<ITeam>();
        private readonly List<IMember> members = new List<IMember>();
        private readonly List<IBoard> boards = new List<IBoard>();

        private readonly List<IBug> bugs = new List<IBug>();
        private readonly List<IStory> stories = new List<IStory>();
        private readonly List<IFeedback> feedbacks = new List<IFeedback>();

        public Database()
        {
            this.SeedData();
        }

        public IList<ITeam> Teams
        {
            get
            {
                return this.teams;
            }
        }

        public IList<IMember> Members
        {
            get
            {
                return this.members;
            }
        }

        public IList<IBoard> Boards
        {
            get
            {
                return this.boards;
            }
        }

        public IList<IBug> Bugs
        {
            get
            {
                return this.bugs;
            }
        }

        public IList<IStory> Stories
        {
            get
            {
                return this.stories;
            }
        }

        public IList<IFeedback> Feedbacks
        {
            get
            {
                return this.feedbacks;
            }
        }

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

        private void SeedData()
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
