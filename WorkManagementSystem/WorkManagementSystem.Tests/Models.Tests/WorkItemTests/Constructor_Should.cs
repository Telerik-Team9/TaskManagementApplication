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
            IBug bug = new Bug("TestBugTitle", "TestBugDescription", default, default, new List<string>()); // 1
            IFeedback feedback = new Feedback("TestFeedbackTitle", "TestFeedbackDescription1", 2, default); // 2
            IStory story = new Story("TestStoryTitle", "TestStoryDescription", default, default, default); // 3

            //Assert
            Assert.AreNotEqual(bug.Id, feedback.Id);
            Assert.AreNotEqual(bug.Id, story.Id);
            Assert.AreNotEqual(feedback.Id, story.Id);
        }
        
        // TODO: Failinh
        [TestMethod]
        public void CorrectlyAssignUniqueId2()
        {
            //Arrange & Act
            IBug bug = new Bug("TestBugTitle", "TestBugDescription", default, default, new List<string>()); 
            IStory story = new Story("TestStoryTitle", "TestStoryDescription", default, default, default); 
            IFeedback feedback = new Feedback("TestFeedbackTitle", "TestFeedbackDescription1", 2, default);

            //Assert
            Assert.AreEqual(bug.Id, 1);
            Assert.AreEqual(story.Id, 2);
            Assert.AreEqual(feedback.Id, 3);
        }
    }
}
