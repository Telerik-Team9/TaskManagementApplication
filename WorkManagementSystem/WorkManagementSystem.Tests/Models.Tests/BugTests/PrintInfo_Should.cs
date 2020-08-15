using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class PrintInfo_Should
    {
        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            IBug bug = new Bug("TestBugTitle", "TestBugDescription", default, default, new List<string>() { "testStep" });
            string expectedPriority = $"Priority: {bug.Priority}";
            string expectedSeverity = $"Severity: {bug.Severity}";
            string expectedStatus = $"Status: {bug.Status}";
            string expectedStepsToReproduce = "testStep";
            string expectedAssignee = $"Assignee:";

            //Act
            string actual = bug.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expectedPriority));
            Assert.IsTrue(actual.Contains(expectedSeverity));
            Assert.IsTrue(actual.Contains(expectedStatus));
            Assert.IsTrue(actual.Contains(expectedStepsToReproduce));
            Assert.IsTrue(actual.Contains(expectedAssignee));
        }
    }
}
