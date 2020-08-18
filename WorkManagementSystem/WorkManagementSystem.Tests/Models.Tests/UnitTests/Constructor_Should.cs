using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.UnitTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CorrectlyInitalize_PassedValues()
        {
            //Arrange
            string name = "TestName";

            //Act
            IUnit member = new Member(name);

            //Assert
            Assert.AreEqual(name, member.Name);
        }

        [TestMethod]
        public void CorrectlyInitalize_Collections()
        {
            //Arrange
            string name = "TestName";

            //Act
            IUnit member = new Member(name);

            //Assert
            Assert.IsInstanceOfType(member.WorkItems, typeof(IList<IWorkItem>));
            Assert.IsInstanceOfType(member.ActivityHistory, typeof(IList<IActivityHistory>));
        }
    }
}
