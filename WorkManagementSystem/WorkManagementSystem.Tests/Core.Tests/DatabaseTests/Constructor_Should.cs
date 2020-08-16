using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.DatabaseTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CorrectlyInitializeDatabase()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db, typeof(IDatabase));
        }

        [TestMethod]
        public void CorrectlyInitializeInstanceOfTeams()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db.Teams, typeof(IList<ITeam>));
        }

        [TestMethod]
        public void CorrectlyInitializeInstanceOfMembers()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db.Members, typeof(IList<IMember>));
        }

        [TestMethod]
        public void CorrectlyInitializeInstanceOfBoards()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db.Boards, typeof(IList<IBoard>));
        }

        [TestMethod]
        public void CorrectlyInitializeInstanceOfBugs()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db.Bugs, typeof(IList<IBug>));
        }

        [TestMethod]
        public void CorrectlyInitializeInstanceOfStories()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db.Stories, typeof(IList<IStory>));
        }

        [TestMethod]
        public void CorrectlyInitializeInstanceOfFeedbacks()
        {
            //Arrange and act
            IDatabase db = new Database();

            //Assert
            Assert.IsInstanceOfType(db.Feedbacks, typeof(IList<IFeedback>));
        }
    }
}
