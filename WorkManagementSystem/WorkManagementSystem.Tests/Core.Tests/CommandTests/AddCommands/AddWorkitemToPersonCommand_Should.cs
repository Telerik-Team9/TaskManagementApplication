﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.AddCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.AddCommands
{
    [TestClass]
    public class AddWorkitemToPersonCommand_Should
    {
        [TestMethod]
        public void Execute_Should_CorectlyAddWorkItemWhen_ValidValuesArePassed()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();
            string memberName = fakeFactory.Database.Members.Skip(1).First().Name;

            IList<string> parameters = new List<string>() { memberName, bugId };
            var command = new AddWorkItemToPersonCommand(fakeFactory);
            string expected = $" assigned to {memberName}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_InvalidWorkitemIdPassed()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string memberName = fakeFactory.Database.Members.First().Name;

            IList<string> parameters = new List<string>() { memberName, "-1" };
            var command = new AddWorkItemToPersonCommand(fakeFactory);

            //Act and Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        public void ThrowWhen_InvalidMemberNamePassed()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string bugId = fakeFactory.Database.Bugs.First().Id.ToString();

            IList<string> parameters = new List<string>() { "a", bugId };
            var command = new AddWorkItemToPersonCommand(fakeFactory);

            //Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}