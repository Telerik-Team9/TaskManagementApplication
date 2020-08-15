using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.TeamTests
{
    [TestClass]
    public class AddBoard_Should
    {
        ITeam cut = new Team("Team 9");

        [TestMethod]
        public void AddBoardCorrectly()
        {
            //Arrange
            IBoard fakeBoard = new FakeBoard();

            //Act
            this.cut.AddBoard(fakeBoard);

            //Assert
            Assert.AreEqual(1, cut.Boards.Count);
            Assert.AreSame(fakeBoard, cut.Boards.First());
        }

        [TestMethod]
        public void ThrowWhen_NullBoardIsPassed()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                this.cut.AddBoard(null);
            });
        }
    }
}
