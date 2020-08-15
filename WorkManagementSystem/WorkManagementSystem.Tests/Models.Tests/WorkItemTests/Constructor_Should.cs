using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.WorkItemTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CorrectlyAssignUniqueId()
        {
            //Arrange & Act
            IBug bug = new Bug("TestBugTitle", "TestBugDescription", default, default, new List<string>());
            IFeedback feedback = new Feedback("TestFeedbackTitle", "TestFeedbackDescription1", 2, default);
            IStory story = new Story("TestStoryTitle", "TestStoryDescription", default, default, default);

            //Assert
            Assert.AreNotEqual(bug.Id, feedback.Id);
            Assert.AreNotEqual(bug.Id, story.Id);
            Assert.AreNotEqual(feedback.Id, story.Id);
        }
    }
}
