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
    public class CreateTeamCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ReturnCorrectMsgWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestTeamName" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateTeamCommand(fakeFactory);
            string expected = $"Team with name '{parameters[0]}' was created";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void Execute_Should_AddTeamToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestTeamName" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateTeamCommand(fakeFactory);

            //Act
            _ = command.Execute(parameters);

            //Assert
            Assert.IsInstanceOfType(fakeFactory.Database.Teams.First(p => p.Name == parameters[0]), typeof(ITeam));
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_MemberAlreadyExists()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestTeamName" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateTeamCommand(fakeFactory);
            _ = command.Execute(parameters);

            //Act & Assert         
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
