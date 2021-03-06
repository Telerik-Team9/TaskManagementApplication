﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.FeedbackTests
{
    [TestClass]
    public class ChangeStatus_Should
    {
        [TestMethod]
        public void AssignCorrectlyStatus()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            FeedbackStatus newStatus = FeedbackStatus.Done;
            IFeedback feedback = new Feedback(title, descr, 5, FeedbackStatus.New);

            //Act
            feedback.ChangeStatus(newStatus);

            //Assert
            Assert.AreEqual(newStatus, feedback.Status);
        }

        [TestMethod]
        public void AddHistoryLogWhen_StatusIsCorrectlyChanged()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            FeedbackStatus newStatus = FeedbackStatus.Done;
            IFeedback feedback = new Feedback(title, descr, 5, FeedbackStatus.New);
            string expected = $"Status changed from {feedback.Status} to {newStatus}.";

            //Act
            feedback.ChangeStatus(newStatus);

            //Assert
            Assert.IsTrue(feedback.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_StatusIsSameAsPassedValue()
        {
            //Arrange
            string title = new string('a', 15);
            string descr = new string('a', 55);
            FeedbackStatus newStatus = FeedbackStatus.Done;

            //Act
            IFeedback feedback = new Feedback(title, descr, 5, FeedbackStatus.Done);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                feedback.ChangeStatus(newStatus);
            });
        }
    }
}
