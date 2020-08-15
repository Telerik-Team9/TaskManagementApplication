using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void AssignCorrectlyStatus()
        {
            //Arrange
            BugStatus status = BugStatus.Fixed;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, default, steps);

            //Act
            bug.ChangeStatus(status);

            //Assert
            Assert.AreEqual(bug.Status, status);
        }

        [TestMethod]
        public void AddHistoryLogWhen_StatusIsCorrectlyChanged()
        {
            //Arrange
            BugStatus status = BugStatus.Fixed;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, default, steps);
            string expected = $"Status changed from {bug.Status} to {status}.";

            //Act
            bug.ChangeStatus(status);

            //Assert
            Assert.IsTrue(bug.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_StatusIsSameAsPassedValue()
        {
            //Arrange
            BugStatus status = BugStatus.Active;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, default, steps);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                bug.ChangeStatus(status);
            });
        }
    }
}
