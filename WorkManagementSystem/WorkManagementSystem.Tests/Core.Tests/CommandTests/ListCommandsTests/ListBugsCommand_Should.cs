using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.ListCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ListCommandsTests
{
    [TestClass]
    public class ListBugsCommand_Should
    {
        [TestMethod]
        [DataRow("Active")]
        [DataRow("Fixed")]
        public void FilterByStatus(string value)
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListBugsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "status", value, "" };
            IList<string> result = fakeFactory.Database
                .Bugs
                .Where(t => t.Status == Enum.Parse<BugStatus>(parameters[1], true))
                .Select(w => w.PrintInfo())
                .ToList();
            string expected = string.Join(Environment.NewLine, result);

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void SortByTitle()
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListBugsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "", "", "title" };
            IList<string> result = fakeFactory.Database
                .Bugs
                .OrderBy(t => t.Title)
                .Select(w => w.PrintInfo())
                .ToList();
            string expected = string.Join(Environment.NewLine, result);

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void SortByPriority()
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListBugsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "", "", "priority" };
            IList<string> result = fakeFactory.Database
                .Bugs
                .OrderBy(t => t.Priority)
                .Select(w => w.PrintInfo())
                .ToList();
            string expected = string.Join(Environment.NewLine, result);

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void SortBySeverity()
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListBugsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "", "", "severity" };
            IList<string> result = fakeFactory.Database
                .Bugs
                .OrderBy(t => t.Severity)
                .Select(w => w.PrintInfo())
                .ToList();
            string expected = string.Join(Environment.NewLine, result);

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_NoAssignedWorkItems()
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListBugsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "assignee", "Aliii", "" };

            //Act & assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
