using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
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
            IStory story = new Story(title, descr, default, default, default);
            IMember member = new FakeMember();

            //Act
            story.ChangeAssignee(member);

            //Assert
            Assert.IsTrue(story.Assignee == member);
        }

        [TestMethod]
        public void AddHistoryWhen_AssigneeChangedCorreclty()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IStory story = new Story(title, descr, default, default, default);
            IMember member = new FakeMember();
            string expected = $"Assigned to";

            //Act
            story.ChangeAssignee(member);

            //Assert
            Assert.IsTrue(story.HistoryLog.Skip(1).First().Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_AssigneeIsSameAsPassed()
        {
            //Arrange
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IStory story = new Story(title, descr, default, default, default);
            IMember member = new FakeMember();

            //Act
            story.ChangeAssignee(member);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                story.ChangeAssignee(member);
            });
        }
    }
}
