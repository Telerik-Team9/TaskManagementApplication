using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.ChangeCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ChangeCommandsTests
{
    [TestClass]
    public class ChangeFeedbackPropertyCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ChangeCorrectlyRatingProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string feedbackId = fakeFactory.Database.Feedbacks.First().Id.ToString();
            IList<string> parameters = new List<string>() { feedbackId, "rating", "6" };
            var command = new ChangeFeedbackPropertyCommand(fakeFactory);
            string expected = $"Feedback {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Feedbacks.First(b => b.Id == int.Parse(feedbackId)).Rating == int.Parse(parameters[2]));
        }

        [TestMethod]
        public void Execute_Should_ChangeCorrectlyStatusProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string feedbackId = fakeFactory.Database.Feedbacks.First().Id.ToString();
            IList<string> parameters = new List<string>() { feedbackId, "status", "scheduled" };
            var command = new ChangeFeedbackPropertyCommand(fakeFactory);
            string expected = $"Feedback {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Feedbacks.First(b => b.Id == int.Parse(feedbackId)).Status == FeedbackStatus.Scheduled);
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_RatingIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string feedbackId = fakeFactory.Database.Feedbacks.First().Id.ToString();
            IList<string> parameters = new List<string>() { feedbackId, "rating", "3" };
            var command = new ChangeFeedbackPropertyCommand(fakeFactory);
            string expected = $"Feedback {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_StatusIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string feedbackId = fakeFactory.Database.Feedbacks.First().Id.ToString();
            IList<string> parameters = new List<string>() { feedbackId, "status", "done" };
            var command = new ChangeFeedbackPropertyCommand(fakeFactory);
            string expected = $"Feedback {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        [DataRow("rating", "wrongrating")]
        [DataRow("status", "wrongstatus")]
        public void Execute_Should_ThrowWhen_InvalidValuesArePassed(string propertyName, string newPropertyValue)
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string feedbackId = fakeFactory.Database.Feedbacks.First().Id.ToString();
            IList<string> parameters = new List<string>() { feedbackId, propertyName, newPropertyValue };
            var command = new ChangeFeedbackPropertyCommand(fakeFactory);
            string expected = $"Feedback {parameters[1]} set to {parameters[2]}";

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
