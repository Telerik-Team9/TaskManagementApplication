using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ShowCommandsTests
{
    [TestClass]
    public class ShowAlTeamMembersCommand_Should
    {
        [TestMethod]
        public void PrintValidInfoWhen_ValidValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllTeamMembersCommand(fakeFactory);
            string firstMemberName = fakeFactory.Database.Teams.First().Members.First().Name;
            string expectedName = $"Name: {firstMemberName}";
            string expectedWorkItems = $"WorkItems:";
            string expectedActivitHistory = $"ActivityHistory:";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expectedName));
            Assert.IsTrue(actual.Contains(expectedWorkItems));
            Assert.IsTrue(actual.Contains(expectedActivitHistory));
        }

        [TestMethod]
        public void ThrowWhen_NoMembersInTeam()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team10" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllTeamMembersCommand(fakeFactory);
            
            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
