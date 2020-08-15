using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
{
    [TestClass]
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void AssignCorrectlyStatus()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            Priority priority = Priority.High;
            StorySize size = StorySize.Medium;
            StoryStatus newStatus = StoryStatus.Done;
            IStory story = new Story(title, descr, priority, size, StoryStatus.InProgress);

            //Act
            story.ChangeStatus(newStatus);

            //Assert
            Assert.AreEqual(newStatus, story.Status);
        }


        [TestMethod]
        public void AddHistoryLogWhen_StatusIsCorrectlyChanged()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            StoryStatus newStatus = StoryStatus.Done;
            IStory story = new Story(title, descr, default, default, StoryStatus.InProgress);
            string expected = $"Status changed from {story.Status} to {newStatus}.";

            //Act
            story.ChangeStatus(newStatus);

            //Assert
            Assert.IsTrue(story.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_StatusIsSameAsPassedValue()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            Priority priority = Priority.High;
            StorySize size = StorySize.Medium;
            StoryStatus newStatus = StoryStatus.Done;
            IStory story = new Story(title, descr, priority, size, newStatus);

            //Act § Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                story.ChangeStatus(newStatus);
            });
        }
    }
}
