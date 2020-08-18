using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ShowCommandsTests
{
    [TestClass]
    public class ShowAllTeamsCommand_Should
    {
        [TestMethod]
        public void PrintValidInfoWhen_ValidValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllTeamsCommand(fakeFactory);
            string expectedName = $"Team name: {parameters[0]}";
            string expectedMembers = $"Members:";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expectedName));
            Assert.IsTrue(actual.Contains(expectedMembers));
        }

        [TestMethod]
        public void ThrowWhen_NoMembersInTeam()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team10" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            fakeFactory.Database.Teams.Clear();
            var command = new ShowAllTeamsCommand(fakeFactory);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
