using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.UnitTests
{
    [TestClass]
    public class AddActivityLog_Should
    {
        [TestMethod]
        public void AddNewActivity()
        {
            //Arrange
            string name = "TestName";
            IUnit member = new Member(name);

            //Act
            member.AddActivityLog("This is a test log.");

            //Assert
            Assert.IsTrue(member.ActivityHistory.Count > 0);
        }
    }
}
