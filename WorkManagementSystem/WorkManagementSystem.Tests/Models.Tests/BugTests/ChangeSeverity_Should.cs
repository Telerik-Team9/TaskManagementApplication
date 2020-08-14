using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class ChangeSeverity_Should
    {
        [TestMethod]
        public void AssignCorrectlySeverity()
        {
            //Arrange
            BugSeverity severity = BugSeverity.Critical;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default,BugSeverity.Major, steps);

            //Act
            bug.ChangeSeverity(severity);

            //Assert
            Assert.AreEqual(bug.Severity, severity);
        }

        [TestMethod]
        public void ThrowWhen_SeverityIsSameAsPassedValue()
        {
            //Arrange
            BugSeverity severity = BugSeverity.Critical;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, BugSeverity.Critical, steps);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                bug.ChangeSeverity(severity);
            });
        }
    }
}
