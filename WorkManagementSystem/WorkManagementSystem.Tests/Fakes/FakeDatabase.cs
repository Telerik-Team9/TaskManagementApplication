using System.Collections.Generic;
using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Fakes
{
    public class FakeDatabase : IDatabase
    {
        private IList<ITeam> teams = new List<ITeam>();
        private IList<IMember> members = new List<IMember>();
        private IList<IBoard> boards = new List<IBoard>();
        private IList<IBug> bugs = new List<IBug>();
        private IList<IStory> stories = new List<IStory>();
        private IList<IFeedback> feedbacks = new List<IFeedback>();

        public FakeDatabase()
        {
            this.SeedFakeData();
        }

        public IList<ITeam> Teams => this.teams;

        public IList<IMember> Members => this.members;

        public IList<IBoard> Boards => this.boards;

        public IList<IBug> Bugs => this.bugs;

        public IList<IStory> Stories => this.stories;

        public IList<IFeedback> Feedbacks => this.feedbacks;

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

            IBug bug = new Bug("SeedDataBug", "SeedDataDescriptionBug", default, default, new List<string>());
            IFeedback feedback = new Feedback("SeedDataFeedback", "SeedDataDescriptionFeedback", 2, default);
            IStory story = new Story("SeedDataStory", "SeedDataDescriptionStory", default, default, default);
            firstBoard.AddWorkItem(bug);
            firstBoard.AddWorkItem(feedback);
            secondBoard.AddWorkItem(story);
            this.Bugs.Add(bug);
            this.Feedbacks.Add(feedback);
            this.Stories.Add(story);
            
            IMember telerikMember = new Member("TelerikMember");
            IMember maggie = new Member("Maggie");
            IMember ali = new Member("Aliii");
            telerikMember.AddActivityLog("A person with name 'TelerikMember' was created.");
            maggie.AddActivityLog("A person with name 'Maggie' was created.");
            ali.AddActivityLog("A person with name 'Aliii' was created.");
            this.Members.Add(telerikMember);
            this.Members.Add(maggie);
            this.Members.Add(ali);
            team9.AddPerson(telerikMember);
            telerikMember.AddWorkItem(bug);


        }
    }
}
