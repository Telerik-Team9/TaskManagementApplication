using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkManagementSystem.Core.Commands.ShowCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ShowCommandsTests
{
    [TestClass]
    public class ShowAllPeopleCommand_Should
    {
        [TestMethod]
        public void PrintNames()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllPeopleCommand(fakeFactory);
            string expectedName = "Name:";

            //Act
            string actual = command.Execute(new List<string>());

            //Assert
            Assert.IsTrue(actual.Contains(expectedName));
        }

        [TestMethod]
        public void PrintActivityHistory()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllPeopleCommand(fakeFactory);
            string expectedHistory = "ActivityHistory:";

            //Act
            string actual = command.Execute(new List<string>());

            //Assert
            Assert.IsTrue(actual.Contains(expectedHistory));
        }

        [TestMethod]
        public void PrintWorkitemsInfo()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllPeopleCommand(fakeFactory);
            string expectedWI = "WorkItems:";

            //Act
            string actual = command.Execute(new List<string>());

            //Assert
            Assert.IsTrue(actual.Contains(expectedWI));
        }

        [TestMethod]
        public void PrintValidInfo()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllPeopleCommand(fakeFactory);
            string expectedName = "Name:";
            string expectedWI = "WorkItems:";
            string expectedHistory = "ActivityHistory:";

            //Act
            string actual = command.Execute(new List<string>());

            //Assert
            Assert.IsTrue(actual.Contains(expectedName));
            Assert.IsTrue(actual.Contains(expectedWI));
            Assert.IsTrue(actual.Contains(expectedHistory));
        }

        [TestMethod]
        public void ReturnCorrectMsgWhen_NoPeopleInDatabase()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ShowAllPeopleCommand(fakeFactory);
            fakeFactory.Database.Members.Clear();
            string expected = "There are currently no people on the list.";

            //Act 
            string actual = command.Execute(new List<string>());

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
