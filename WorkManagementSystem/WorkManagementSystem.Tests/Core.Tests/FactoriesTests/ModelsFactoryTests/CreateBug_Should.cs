using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.ModelsFactoryTests
{
    [TestClass]
    public class CreateBug_Should
    {
        [TestMethod]
        public void CreatePersonWhen_ValidValuesArePassed()
        {
            //Arrange
            string title = new string('a', 11);
            string descr = new string('a', 11);
            List<string> steps = new List<string>() { "first", "second" };
            IModelsFactory factory = new ModelsFactory();

            //Act
            IBug bug = factory.CreateBug(title, descr, default, default, steps);

            //Assert
            Assert.AreEqual(title, bug.Title);
            Assert.AreEqual(descr, bug.Description);
            Assert.IsNotNull(bug.StepsToReproduce);
            Assert.IsInstanceOfType(bug, typeof(IBug));
        }
    }
}
