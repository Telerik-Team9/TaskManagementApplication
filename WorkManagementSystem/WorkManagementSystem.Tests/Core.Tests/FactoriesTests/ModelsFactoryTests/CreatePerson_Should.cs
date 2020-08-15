using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.ModelsFactoryTests
{
    [TestClass]
    public class CreatePerson_Should
    {
        [TestMethod]
        public void CreatePersonWhen_ValidValuesArePassed()
        {
            //Arrange
            string name = "Maggie";
            IModelsFactory factory = new ModelsFactory();

            //Act
            IMember member = factory.CreatePerson(name);

            //Assert
            Assert.IsInstanceOfType(member, typeof(IMember));
            Assert.AreEqual(name, member.Name);
        }
    }
}
