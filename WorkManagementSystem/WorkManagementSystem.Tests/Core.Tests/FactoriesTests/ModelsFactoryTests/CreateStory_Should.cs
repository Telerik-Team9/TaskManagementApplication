using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.ModelsFactoryTests
{
    [TestClass]
    public class CreateStory_Should
    {
        [TestMethod]
        public void CreateStoryWhen_ValidValuesArePassed()
        {
            //Arrange
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IModelsFactory factory = new ModelsFactory();

            //Act
            IStory story = factory.CreateStory(title, descr, default, default, default);

            //Assert
            Assert.AreEqual(title, story.Title);
            Assert.AreEqual(descr, story.Description);
            Assert.IsInstanceOfType(story, typeof(IStory));
        }
    }
}
