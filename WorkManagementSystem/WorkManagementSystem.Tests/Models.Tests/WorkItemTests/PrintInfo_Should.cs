using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.WorkItemTests
{
    [TestClass]
    public class PrintInfo_Should
    {
        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            IBug bug = new Bug("TestBugTitle", "TestBugDescription", default, default, new List<string>());
            string expectedId = $"Id: {bug.Id}";
            string expectedTitle = $"Title: {bug.Title}";
            string expectedDescription = $"Description: {bug.Description}";
            string expectedComments = "No comments added yet";
            string expectedHistory = $"Bug with title '{bug.Title}' created";

            //Act
            string actual = bug.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expectedId));
            Assert.IsTrue(actual.Contains(expectedTitle));
            Assert.IsTrue(actual.Contains(expectedDescription));
            Assert.IsTrue(actual.Contains(expectedComments));
            Assert.IsTrue(actual.Contains(expectedHistory));
        }
    }
}
