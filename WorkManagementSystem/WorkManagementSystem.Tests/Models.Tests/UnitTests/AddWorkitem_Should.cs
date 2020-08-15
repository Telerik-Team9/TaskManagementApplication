using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.UnitTests
{
    [TestClass]
    public class AddWorkitem_Should
    {
        [TestMethod]
        public void AddCorrectlyWorkitemToPerson()
        {
            //Arrange
            IMember member = new Member("TestMember");
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IWorkItem feedback = new Feedback(title, descr, 5, default);

            //Act
            member.AddWorkItem(feedback);

            //Assert
            Assert.IsTrue(member.WorkItems.First() == feedback);
        }

        [TestMethod]
        public void ThrowWhen_ItemAlreadyExists()
        {
            //Arrange
            IBoard board = new Board("TestBoard");
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IWorkItem feedback = new Feedback(title, descr, 5, default);

            //Act
            board.AddWorkItem(feedback);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                board.AddWorkItem(feedback);
            });
        }

        [TestMethod]
        public void AddHistoryLogWhen_ItemAddedSuccessfully()
        {
            //Arrange
            IBoard board = new Board("TestBoard");
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IWorkItem feedback = new Feedback(title, descr, 5, default);

            //Act
            board.AddWorkItem(feedback);

            //Assert
            Assert.IsTrue(board.ActivityHistory.Count != 0);
        }
    }
}
