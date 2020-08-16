using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.Tests.Core.Tests.Common.ListMethodsTests
{
    [TestClass]
    public class ListAllTeams_Should
    {
        [TestMethod]
        public void ListCorrectlyAllTeams()
        {
            //Arrange
            InstanceFactory factory = new InstanceFactory();
            string expected = "Team9\r\nTeam10";

            //Act
            string actual = ListMethods.ListAllTeams(factory, x => x.Name);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowWhen_NoTeamsIsDatabase()
        {
            //Arrange
            InstanceFactory factory = new InstanceFactory();
            factory.Database.Teams.Clear();

            //Act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                string actual = ListMethods.ListAllTeams(factory, x => x.Name);
            });

        }
    }
}
