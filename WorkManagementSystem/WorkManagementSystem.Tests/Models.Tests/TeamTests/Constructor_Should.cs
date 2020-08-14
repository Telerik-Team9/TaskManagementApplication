using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.TeamTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateTeamWhen_ValidValuesArePassed()
        {
            //Arrange
            string name = "Team 9";

            //Act
            ITeam team = new Team(name);

            //Assert
            Assert.AreEqual(team.Name, name);
            Assert.IsInstanceOfType(team, typeof(ITeam));
        }

        [TestMethod]
        public void InitializeCorrectlyCollections()
        {
            //Act
            ITeam cut = new Team("Team 9");

            //Assert
            Assert.IsInstanceOfType(cut.Members, typeof(IList<IMember>));
            Assert.IsInstanceOfType(cut.Boards, typeof(IList<IBoard>));
            Assert.IsInstanceOfType(cut.ActivityHistory, typeof(IList<IActivityHistory>));
        }
    }
}
