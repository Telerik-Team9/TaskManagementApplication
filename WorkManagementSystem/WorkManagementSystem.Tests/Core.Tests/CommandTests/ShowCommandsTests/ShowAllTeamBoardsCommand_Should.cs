using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ShowCommandsTests
{
    [TestClass]
    public class ShowAllTeamBoardsCommand_Should
    {
        [TestMethod]
        public void PrintValidInfoWhen_ValidValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllTeamBoardsCommand(fakeFactory);
            string boardName = fakeFactory.Database.Teams.First().Boards.First().Name;
            string expectedName = $"Name: {boardName}";
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
        public void ThrowWhen_NoBoardsInTeam()
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
