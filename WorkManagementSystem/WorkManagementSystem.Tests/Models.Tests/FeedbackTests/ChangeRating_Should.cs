using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.FeedbackTests
{
    [TestClass]
    public class ChangeRating_Should
    {
        [TestMethod]
        public void AssignCorrectlyRating()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            int newRating = 5;
            IFeedback feedback = new Feedback(title, descr, 3, default);

            //Act
            feedback.ChangeRating(newRating);

            //Assert
            Assert.AreEqual(newRating, feedback.Rating);
        }

        [TestMethod]
        public void AddHistoryLogWhen_RatingIsCorrectlyChanged()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            int newRating = 5;
            IFeedback feedback = new Feedback(title, descr, 3, default);
            string expected = $"Rating changed from {feedback.Rating} to {newRating}.";

            //Act
            feedback.ChangeRating(newRating);

            //Assert
            Assert.IsTrue(feedback.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_RatingIsSameAsPassedValue()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IFeedback feedback = new Feedback(title, descr, 3, default);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                feedback.ChangeRating(3);
            });
        }
    }
}
