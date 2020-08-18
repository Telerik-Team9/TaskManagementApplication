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
    public class CreateBugCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ReturnCorrectMsgWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD", "TestBugTitle", "TestBugDescription", "medium", "minor", "one-two" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateBugCommand(fakeFactory);
            string expected = "Bug with title 'TestBugTitle' created";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void Execute_Should_AddBugToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD", "TestBugTitle", "TestBugDescription", "medium", "minor", "one-two" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateBugCommand(fakeFactory);

            //Act
            _ = command.Execute(parameters);

            //Assert
            Assert.IsInstanceOfType(fakeFactory.Database.Bugs.First(p => p.Title == parameters[2]), typeof(IBug));
        }
    }
}
