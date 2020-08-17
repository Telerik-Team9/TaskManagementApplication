using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.ChangeCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ChangeCommandsTests
{
    [TestClass]
    public class ChangeStoryPropertyCommand_Should
    {
        [TestMethod]
        public void Execute_Should_ChangeCorrectlyPriortyProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, "medium", "priority" };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[2]} set to {parameters[1]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Stories.First(s => s.Id == int.Parse(parameters[0])).Priority == Priority.Medium);
        }

        [TestMethod]
        public void Execute_Should_ChangeCorrectlySizeProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, "large", "size" };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[2]} set to {parameters[1]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Stories.First(s => s.Id == int.Parse(parameters[0])).Size == StorySize.Large);
        }

        [TestMethod]
        public void Execute_Should_ChangeCorrectlyStatusProperty()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, "inprogress", "status" };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[2]} set to {parameters[1]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
            Assert.IsTrue(fakeFactory.Database.Stories.First(s => s.Id == int.Parse(parameters[0])).Status == StoryStatus.InProgress);
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_PriorityIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, "medium", "priority" };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[2]} set to {parameters[1]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        public void Execute_Should_ThrowWhen_SizeIsSame()
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, "large", "size" };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[2]} set to {parameters[1]}";

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
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, "inprogress", "status" };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[2]} set to {parameters[1]}";

            //Act
            string actual = command.Execute(parameters);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }

        [TestMethod]
        [DataRow("wrongpririty", "priority")]
        [DataRow("wrongstatus", "status")]
        [DataRow("wrongsize", "size")]
        public void Execute_Should_ThrowWhen_InvalidValuesArePassed(string newPropertyValue, string propertyName)
        {
            //Arrange
            IInstanceFactory fakeFactory = new FakeInstanceFactory();
            string storyId = fakeFactory.Database.Stories.First().Id.ToString();
            IList<string> parameters = new List<string>() { storyId, newPropertyValue, propertyName };
            var command = new ChangeStoryPropertyCommand(fakeFactory);
            string expected = $"Story {parameters[1]} set to {parameters[2]}";

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _ = command.Execute(parameters);
            });
        }
    }
}
