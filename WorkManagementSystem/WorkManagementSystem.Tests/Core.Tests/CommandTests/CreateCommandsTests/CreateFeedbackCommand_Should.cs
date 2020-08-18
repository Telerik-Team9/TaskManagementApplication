using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.CreateCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.CreateCommandsTests
{
    [TestClass]
    public class CreateFeedbackCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ReturnCorrectMsg_When_ValidValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD", "TestFeedbackTitle", "TestFeedbackDescription", "6", "new" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateFeedbackCommand(fakeFactory);
            string expected = "Feedback with title 'TestFeedbackTitle' created";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void Execute_Should_AddFeedbackToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD", "TestFeedbackTitle", "TestFeedbackDescription", "6", "new" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateFeedbackCommand(fakeFactory);

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsInstanceOfType(fakeFactory.Database.Feedbacks.First(p => p.Title == parameters[2]), typeof(IFeedback));
        }
    }
}
