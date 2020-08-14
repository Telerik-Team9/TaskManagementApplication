using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.FeedbackTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        [DataRow("TestFeedbackTitle", "TestFeedbackDescription1", 2, FeedbackStatus.New)]
        [DataRow("TestFeedbackTitle3", "TestFeedbackDescription2", 1, FeedbackStatus.Done)]
        [DataRow("TestFeedbackTitle4", "TestFeedbackDescription3", 9, default)]
        public void CreateFeedbackWhen_ValidValuesArePassed(string title, string descr, int rating, FeedbackStatus status)
        {
            //Act
            IFeedback feedback = new Feedback(title, descr, rating, status);

            //Assert
            Assert.AreEqual(title, feedback.Title);
            Assert.AreEqual(descr, feedback.Description);
            Assert.AreEqual(rating, feedback.Rating);
            Assert.AreEqual(status, feedback.FeedbackStatus);
            Assert.IsInstanceOfType(feedback, typeof(IFeedback));
        }
    }
}
