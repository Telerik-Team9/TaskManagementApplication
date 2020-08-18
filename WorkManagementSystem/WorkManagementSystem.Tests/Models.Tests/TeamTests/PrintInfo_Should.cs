using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.TeamTests
{
    [TestClass]
    public class PrintInfo_Should
    {
        ITeam cut = new Team("Team 9");

        [TestMethod]
        public void ReturnMsgWhen_MembersCollectionIsEmpty()
        {
            //Arrange
            string expected = "No members in team.";

            //Act
            string actual = this.cut.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void ReturnMsgWhen_BoardsCollectionIsEmpty()
        {
            //Arrange
            string expected = "No boards in team.";

            //Act
            string actual = this.cut.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void IterateTroughMembersCollection()
        {
            //Arrange
            IMember member = new FakeMember();
            this.cut.AddPerson(member);
            string expected = member.Name;

            //Act
            string actual = this.cut.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void IterateTroughBoardsCollection()
        {
            //Arrange
            IBoard board = new FakeBoard();
            this.cut.AddBoard(board);
            string expected = board.Name;

            //Act
            string actual = this.cut.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
