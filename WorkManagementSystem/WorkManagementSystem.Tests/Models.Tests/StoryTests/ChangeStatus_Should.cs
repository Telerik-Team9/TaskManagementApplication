using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

            //Act
            IStory story = new Story(title, descr, priority, size, StoryStatus.InProgress);
            story.ChangeStatus(newStatus);

            //Assert
            Assert.AreEqual(newStatus, story.Status);
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

            //Act
            IStory story = new Story(title, descr, priority, size, newStatus);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                story.ChangeStatus(newStatus);
            });
        }
    }
}
