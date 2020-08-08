using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class TeamShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedName = "Test name";

            //Act
            Team team = new Team(expectedName);
            string actualName = team.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ShouldThrowExceptionOnNullInput()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Team team = new Team(null);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnShorterInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Team team = new Team(new string('a', 2));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionOnLongerInputLength()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Team team = new Team(new string('a', 16));
            });
        }
    }
}
