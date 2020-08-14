using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.TeamTests
{
    [TestClass]
    public class PrintActivityHistory_Should
    {
        [TestMethod]
        public void IterateThroughActivityHistoryCollection()
        {
            //Arrange
            ITeam cut = new Team("Team 9");
            string expected = $"Team Team 9 was created.";

            //Act
            string actual = cut.PrintActivityHistory();

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
