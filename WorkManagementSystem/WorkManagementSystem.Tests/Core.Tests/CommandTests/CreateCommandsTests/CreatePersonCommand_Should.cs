using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
    public class CreatePersonCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ReturnCorrectMsgWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestPersonName" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new CreatePersonCommand(fakeFactory);
            string expected = "Member TestPersonName has been created";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void Execute_Should_AddPersonToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestPersonName" };
            IInstanceFactory factory = new FakeInstanceFactory();
            var command = new CreatePersonCommand(factory);

            //Act
            _ = command.Execute(parameters);

            //Assert
            Assert.IsInstanceOfType(factory.Database.Members.First(p => p.Name == parameters[0]), typeof(IMember));
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_MemberAlreadyExists()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestPersonName" };
            IInstanceFactory factory = new FakeInstanceFactory();
            var command = new CreatePersonCommand(factory);
            _ = command.Execute(parameters);

            //Act & Assert         
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
