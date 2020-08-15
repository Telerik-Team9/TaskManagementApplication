using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.TeamTests
{
    [TestClass]
    public class AddPerson_Should
    {
        ITeam cut = new Team("Team 9");

        [TestMethod]
        public void AddMemberCorrectly()
        {
            //Arrange
            IMember fakeMember = new FakeMember();

            //Act
            this.cut.AddPerson(fakeMember);

            //Assert
            Assert.AreEqual(1, cut.Members.Count);
            Assert.AreSame(fakeMember, cut.Members.First());
        }

        [TestMethod]
        public void ThrowWhen_NullBoardIsPassed()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                this.cut.AddPerson(null);
            });
        }
    }
}
