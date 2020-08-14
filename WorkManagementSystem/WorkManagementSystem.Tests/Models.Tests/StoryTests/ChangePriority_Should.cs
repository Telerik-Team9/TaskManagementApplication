using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
{
    [TestClass]
    public class ChangePriority_Should
    {
        [TestMethod]
        public void AssignCorrectlyPriority()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            Priority newPriority = Priority.High;
            StorySize size = StorySize.Medium;
            StoryStatus status = StoryStatus.Done;

            //Act
            IStory story = new Story(title, descr, Priority.Low, size, status);

            //Act
            story.ChangePriority(newPriority);

            //Assert
            Assert.AreEqual(story.Priority, newPriority);
        }

        [TestMethod]
        public void ThrowWhen_PriortyIsSameAsPassedValue()
        {
            //Arrange
            Priority priority = Priority.High;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            StorySize size = StorySize.Medium;
            StoryStatus status = StoryStatus.Done;

            //Act
            IStory story = new Story(title, descr, priority, size, status);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                story.ChangePriority(priority);
            });
        }
    }
}
