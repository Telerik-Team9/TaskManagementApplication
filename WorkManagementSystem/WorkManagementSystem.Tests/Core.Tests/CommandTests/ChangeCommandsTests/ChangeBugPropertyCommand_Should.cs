using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.ChangeCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ChangeCommandsTests
{
    [TestClass]
    public class ChangeBugPropertyCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ChangeCorrectlyPriortyProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            IList<string> parameters = new List<string>() { bugId, "priority", "medium" };
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = $"Bug {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Bugs.First(b => b.Id == int.Parse(parameters[0])).Priority == Priority.Medium);
        }

        [TestMethod]
        public void Execute_Should_ChangeCorrectlySeverityProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            IList<string> parameters = new List<string>() { bugId, "severity", "major" };
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = $"Bug {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Bugs.First(b => b.Id == int.Parse(parameters[0])).Severity == BugSeverity.Major);
        }

        [TestMethod]
        public void Execute_Should_ChangeCorrectlyStatusProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            IList<string> parameters = new List<string>() { bugId, "status", "fixed" };
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = $"Bug {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Bugs.First(b => b.Id == int.Parse(parameters[0])).Status == BugStatus.Fixed);
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_PriorityIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            IList<string> parameters = new List<string>() { bugId, "priority", "medium" };
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = $"Bug {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_SeverityIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            IList<string> parameters = new List<string>() { bugId, "status", "fixed" };
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = $"Bug {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_StatusIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            IList<string> parameters = new List<string>() { bugId, "severity", "major" };
            var command = new ChangeBugPropertyCommand(fakeFactory);
            string expected = $"Bug {parameters[1]} set to {parameters[2]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
