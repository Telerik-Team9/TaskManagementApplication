using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.CreateCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.CreateCommandsTests
{
    [TestClass]
    public class CreateBoardInTeamCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ReturnCorrectMsgWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "TestBrd" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateBoardInTeamCommand(fakeFactory);
            string expected = "A board with name 'TestBrd' has been added to Team9 team";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
        
        [TestMethod]
        public void Execute_Should_AddBoardToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "TestBrd" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateBoardInTeamCommand(fakeFactory);

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsInstanceOfType(fakeFactory.Database.Boards.First(p => p.Name == parameters[1]), typeof(IBoard));
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_BoardAlreadyExists()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "Team9", "TestBrd" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreateBoardInTeamCommand(fakeFactory);

            //Act
            string actual = command.Execute(parameters);

            //Act & Assert         
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
