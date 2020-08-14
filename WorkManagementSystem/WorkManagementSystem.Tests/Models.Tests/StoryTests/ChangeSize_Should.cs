using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            Priority priority = Priority.High;
            StorySize newSize = StorySize.Medium;
            StoryStatus status = StoryStatus.Done;

            //Act
            IStory story = new Story(title, descr, priority, StorySize.Small, status);
            story.ChangeSize(newSize);

            //Assert
            Assert.AreEqual(status, story.Status);
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
