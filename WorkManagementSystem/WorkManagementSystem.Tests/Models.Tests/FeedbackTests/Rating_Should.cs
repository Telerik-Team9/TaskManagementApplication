using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.FeedbackTests
{
    [TestClass]
    public class Rating_Should
    {
        [TestMethod]
        public void AssingPassedValueCorrectly()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);

            //Act
            IFeedback feedback = new Feedback(title, descr, 3, default);

            //Assert
            Assert.AreEqual(3, feedback.Rating);
        }

        [TestMethod]
        public void ThrowWhen_ValueLessThanMin()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IFeedback feedback = new Feedback(title, descr, 0, default);
            });
        }

        [TestMethod]
        public void ThrowWhen_ValueMoreThanMax()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IFeedback feedback = new Feedback(title, descr, 11, default);
            });
        }
    }
}
