using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.StoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        [DataRow("TestStoryTitle", "TestStoryDescription", default, default, default)]
        [DataRow("TestStoryTitle2", "TestStoryDescription2", Priority.High, StorySize.Large, StoryStatus.Done)]
        [DataRow("TestStoryTitle3", "TestStoryDescription3", Priority.Low, StorySize.Medium, StoryStatus.InProgress)]
        public void CreateStoryWhen_ValidValuesArePassed(string title, string descr, Priority priority, StorySize size, StoryStatus status)
        {
            //Act
            IStory story = new Story(title, descr, priority, size, status);

            //Assert
            Assert.AreEqual(title, story.Title);
            Assert.AreEqual(descr, story.Description);
            Assert.AreEqual(priority, story.Priority);
            Assert.AreEqual(size, story.Size);
            Assert.AreEqual(status, story.Status);
            Assert.IsInstanceOfType(story, typeof(IStory));
        }
    }
}
