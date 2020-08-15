using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class ChangeAssignee_Should
    {
        [TestMethod]
        public void ChangeCorrectlyAssignee()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, default, steps);
            IMember member = new FakeMember();

            //Act
            bug.ChangeAssignee(member);

            //Assert
            Assert.IsTrue(bug.Assignee == member);
        }

        [TestMethod]
        public void AddHistoryWhen_AssigneeChangedCorreclty()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, default, steps);
            IMember member = new FakeMember();
            string expected = $"Assigned from";

            //Act
            bug.ChangeAssignee(member);

            //Assert
            Assert.IsTrue(bug.HistoryLog.First().Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_AssigneeIsSameAsPassed()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, default, default, steps);
            IMember member = new FakeMember();

            //Act
            bug.ChangeAssignee(member);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                bug.ChangeAssignee(member);
            });
        }
    }
}