/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Commands.ChangeCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ChangeCommandsTests
{
    [TestClass]
    public class ChangeBugPropertyCommand_Should
    {
        [TestMethod]
        public void Execute_Should_CorrectlyChangeBugPriorityProperty()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "0", "priority", "medium" };
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            fakeFactory.Database.SeedFakeData();
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = "Bug priority set to medium";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

*//*        [TestMethod]
        public void Execute_Should_AddPersonToDatabaseWhen_ValiedValuesArePassed()
        {
            //Arrange
            IList<string> parameters = new List<string>() { "TestPersonName" };
            IInstanceFactory factory = new InstanceFactory();
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
            IInstanceFactory factory = new InstanceFactory();
            var command = new CreatePersonCommand(factory);
            _ = command.Execute(parameters);

            //Act & Assert         
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }*//*
    }
}
*/