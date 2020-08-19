using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        [DataRow("TestBugTitle", "TestBugDescription", default, default)]
        [DataRow("TestBugTitle2", "TestBugDescription2", Priority.High, BugSeverity.Major)]
        [DataRow("TestBugTitle3", "TestBugDescription3", Priority.Low, BugSeverity.Critical)]
        [DataRow("TestBugTitle4", "TestBugDescription4", Priority.Medium, default)]
        public void CreateBugWhen_ValidValuesArePassed(string title, string descr, Priority priority, BugSeverity severity)
        {
            //Arrange
            IList<string> list = new List<string>() { "steps", "to", "reproduce" };

            //Act
            IBug bug = new Bug(title, descr, priority, severity, list);

            //Assert
            Assert.AreEqual(bug.Title, title);
            Assert.AreEqual(bug.Description, descr);
            Assert.AreEqual(bug.Priority, priority);
            Assert.AreEqual(bug.Severity, severity);
            Assert.IsNotNull(bug.StepsToReproduce);
            Assert.IsInstanceOfType(bug, typeof(IBug));
        }
    }
}
