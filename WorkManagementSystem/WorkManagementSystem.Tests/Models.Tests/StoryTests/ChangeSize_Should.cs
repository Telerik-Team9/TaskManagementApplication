using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
{
    [TestClass]
    public class ChangeSize_Should
    {

        [TestMethod]
        public void AssignCorrectlyStatus()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            StorySize newSize = StorySize.Medium;
            IStory story = new Story(title, descr, default, StorySize.Small, default);

            //Act
            story.ChangeSize(newSize);

            //Assert
            Assert.AreEqual(story.Size, newSize);
        }

        [TestMethod]
        public void AddHistoryLogWhen_SizeIsCorrectlyChanged()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            StorySize newSize = StorySize.Medium;
            IStory story = new Story(title, descr, default, StorySize.Small, default);
            string expected = $"Size changed from {story.Size} to {newSize}.";

            //Act
            story.ChangeSize(newSize);

            //Assert
            Assert.IsTrue(story.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_SizeIsSameAsPassedValue()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            Priority priority = Priority.High;
            StorySize newSize = StorySize.Medium;
            StoryStatus status = StoryStatus.Done;

            //Act
            IStory story = new Story(title, descr, priority, newSize, status);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                story.ChangeSize(newSize);
            });
        }
    }
}
