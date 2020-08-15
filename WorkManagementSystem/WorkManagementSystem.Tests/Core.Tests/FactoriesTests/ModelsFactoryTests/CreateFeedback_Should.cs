using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.ModelsFactoryTests
{
    [TestClass]
    public class CreateFeedback_Should
    {
        [TestMethod]
        public void CreateFeedbaclWhen_ValidValuesArePassed()
        {
            //Arrange
            string title = new string('a', 11);
            string descr = new string('a', 11);
            IModelsFactory factory = new ModelsFactory();

            //Act
            IFeedback feedback = factory.CreateFeedback(title, descr, 5, default);

            //Assert
            Assert.AreEqual(title, feedback.Title);
            Assert.AreEqual(descr, feedback.Description);
            Assert.IsInstanceOfType(feedback, typeof(IFeedback));
        }
    }
}
