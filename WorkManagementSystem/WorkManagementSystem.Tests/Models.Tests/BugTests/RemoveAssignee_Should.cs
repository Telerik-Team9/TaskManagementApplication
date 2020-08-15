using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class RemoveAssignee_Should
    {
        [TestMethod]
        public void RemoveCorrectlyAssignee()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IBug bug = new Bug(title, descr, default, default, new List<string>());
            IMember member = new FakeMember();

            //Act
            bug.RemoveAssignee(member);

            //Assert
            Assert.IsNull(bug.Assignee);
        }

        [TestMethod]
        public void AddHistoryWhen_AssigneeRemovedCorrectly()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IBug bug = new Bug(title, descr, default, default, new List<string>());
            IMember member = new FakeMember();
            string expected = $"Unassigned from {member.Name}";

            //Act
            bug.RemoveAssignee(member);

            //Assert
            Assert.IsTrue(bug.HistoryLog.Skip(1).First().Contains(expected));
        }
    }
}