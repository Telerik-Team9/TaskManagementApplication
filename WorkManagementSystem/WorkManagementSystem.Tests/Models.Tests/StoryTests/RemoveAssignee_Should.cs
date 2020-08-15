using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
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
            IStory story = new Story(title, descr, default, default, default);
            IMember member = new FakeMember();

            //Act
            story.RemoveAssignee(member);

            //Assert
            Assert.IsNull(story.Assignee);
        }

        [TestMethod]
        public void AddHistoryWhen_AssigneeRemovedCorrectly()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IStory story = new Story(title, descr, default, default, default);
            IMember member = new FakeMember();
            string expected = $"Unassigned from {member.Name}";

            //Act
            story.RemoveAssignee(member);

            //Assert
            Assert.IsTrue(story.HistoryLog.Skip(1).First().Contains(expected));
        }
    }
}
