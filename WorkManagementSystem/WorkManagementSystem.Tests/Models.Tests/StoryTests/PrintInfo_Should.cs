using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
{
    [TestClass]
    public class PrintInfo_Should
    {
        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            IStory story = new Story("TestStoryTitle", "TestDescription", default, default, default);
            string expectedPriority = $"Priority: {story.Priority}";
            string expectedSeverity = $"Size: {story.Size}";
            string expectedStatus = $"Status: {story.Status}";
            string expectedAssignee = $"Assignee:";

            //Act
            string actual = story.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expectedPriority));
            Assert.IsTrue(actual.Contains(expectedSeverity));
            Assert.IsTrue(actual.Contains(expectedStatus));
            Assert.IsTrue(actual.Contains(expectedAssignee));
        }
    }
}
