using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.DatabaseTests.ConstructorTests
{
    [TestClass]
    public class SeedData_Should
    {
        [TestMethod]
        public void AddTeamsToDataBase()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Teams.Count != 0);
        }

        [TestMethod]
        public void AddBoardsToDataBase()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Boards.Count != 0);
        }

        [TestMethod]
        public void AddMembersToDataBase()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Members.Count != 0);
        }

        [TestMethod]
        public void AddBugsToDataBase()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Bugs.Count != 0);
        }

        [TestMethod]
        public void AddStoriesToDataBase()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Stories.Count != 0);
        }

        [TestMethod]
        public void AddFeedbacksToDataBase()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Feedbacks.Count != 0);
        }

        [TestMethod]
        public void AddBoardToTeam()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Teams[0].Boards.Count != 0);
        }

        [TestMethod]
        public void AddActivityLogToBoard()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Boards[0].ActivityHistory.Count != 0);
        }

        [TestMethod]
        public void AddWorkItemToBoard()
        {
            //Arrange
            IDatabase db = new Database();

            //Assert
            Assert.IsTrue(db.Boards[0].WorkItems.Count != 0);
        }
    }
}
