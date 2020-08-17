using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ShowCommandsTests
{
    [TestClass]
    public class ShowBoardsActivityCommand_Should
    {
        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            IInstanceFactory factory = new FakeInstanceFactory();
            IList<string> parameters = new List<string>() { "Team9", "FIRSTBRD" };
            ITeam team = factory.Database.Teams.First(p => p.Name == parameters[0]);
            IBoard board = team.Boards.First(b => b.Name == parameters[1]);
            var command = new ShowBoardActivityCommand(factory);
            string expected = board.PrintActivityHistory();

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
