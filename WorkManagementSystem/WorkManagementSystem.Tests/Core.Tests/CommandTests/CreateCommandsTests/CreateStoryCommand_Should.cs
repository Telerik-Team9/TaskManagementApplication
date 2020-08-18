using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.CreateCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.CreateCommandsTests
{
    [TestClass]
    public class CreateStoryCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ReturnCorrectMsgWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD", "TestStoryTitle", "TestStoryDescription", "high", "medium", "inprogress" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateStoryCommand(fakeFactory);
            string expected = "Story with title 'TestStoryTitle' was created";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void Execute_Should_AddBugToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD", "TestStoryTitle", "TestStoryDescription", "high", "medium", "inprogress" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateStoryCommand(fakeFactory);

            //Act
            _ = command.Execute(parameters);

            //Assert
            Assert.IsInstanceOfType(fakeFactory.Database.Stories.First(s => s.Title == parameters[2]), typeof(IStory));
        }
    }
}
