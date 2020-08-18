using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.AddCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.AddCommands
{
    [TestClass]
    public class AddPersonToTeamCommand_Should
    {
        [TestMethod]
        public void Execute_Should_CorectlyAddWorkItemWhen_ValidValuesArePassed()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string teamName = fakeFactory.Database.Teams.First().Name;
            IList<string> parameters = new List<string>() { teamName, "Maggie" };
            var command = new AddPersonToTeamCommand(fakeFactory);
            string expected = $"{parameters[1]} has been added to {parameters[0]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_InvalidPersonNameIsPassed()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string teamName = fakeFactory.Database.Teams.First().Name;
            IList<string> parameters = new List<string>() { teamName, "WrongMember" };
            var command = new AddPersonToTeamCommand(fakeFactory);

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        public void ThrowWhen_PersonIsAlreadyOnTeam()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string teamName = fakeFactory.Database.Teams.First().Name;
            IList<string> parameters = new List<string>() { teamName, "Maggie" };
            var command = new AddPersonToTeamCommand(fakeFactory);
            _ = command.Execute(parameters);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
