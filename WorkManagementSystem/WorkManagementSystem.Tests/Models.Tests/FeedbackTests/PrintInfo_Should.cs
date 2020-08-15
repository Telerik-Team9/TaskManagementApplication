using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.FeedbackTests
{
    [TestClass]
    public class PrintInfo_Should
    {
        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            IFeedback feedback = new Feedback("TestFeedback", "TestDescription", 2, default);
            string expectedRating = $"Rating: {feedback.Rating}";
            string expectedStatus = $"Status: {feedback.Status}";

            //Act
            string actual = feedback.PrintInfo();

            //Assert
            Assert.IsTrue(actual.Contains(expectedRating));
            Assert.IsTrue(actual.Contains(expectedStatus));
        }
    }
}
