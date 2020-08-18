using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.ListCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ListCommandsTests
{
    [TestClass]
    public class ListWorkItemsCommand_Should
    {
        [TestMethod]
        public void SortWorkitemsByTitle()
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListWorkItemsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "title" };
            IList<string> result = fakeFactory.Database
                .ListAllWorkitems()
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
        public void SortWorkitemsByDefault()
        {
            //Arrnge
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            var command = new ListWorkItemsCommand(fakeFactory);
            IList<string> parameters = new List<string>() { "no" };
            IList<string> result = fakeFactory.Database
                .ListAllWorkitems()
                .OrderBy(t => t.Id)
                .Select(w => w.PrintInfo())
                .ToList();
            string expected = string.Join(Environment.NewLine, result);


            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}
