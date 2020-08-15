using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
            IStory story = new Story(title, descr, Priority.Low, default, default);

            //Act
            story.ChangePriority(newPriority);

            //Assert
            Assert.AreEqual(story.Priority, newPriority);
        }

        [TestMethod]
        public void AddHistoryLogWhen_PriorityIsCorrectlyChanged()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            Priority newPriority = Priority.High;
            IStory story = new Story(title, descr, Priority.Low, default, default);
            string expected = $"Priority changed from {story.Priority} to {newPriority}.";

            //Act
            story.ChangePriority(newPriority);

            //Assert
            Assert.IsTrue(story.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_PriortyIsSameAsPassedValue()
        {
            //Arrange
            Priority priority = Priority.High;
            string title = new string('a', 15);
            string descr = new string('a', 55);

            //Act
            IStory story = new Story(title, descr, priority, default, default);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                story.ChangePriority(priority);
            });
        }
    }
}
