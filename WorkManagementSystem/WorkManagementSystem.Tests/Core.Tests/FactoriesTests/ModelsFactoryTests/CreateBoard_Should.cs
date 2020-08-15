using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.ModelsFactoryTests
{
    [TestClass]
    public class CreateBoard_Should
    {
        [TestMethod]
        public void CreatePersonWhen_ValidValuesArePassed()
        {
            //Arrange
            string name = "FirstBoard";
            IModelsFactory factory = new ModelsFactory();

            //Act
            IBoard board = factory.CreateBoard(name);

            //Assert
            Assert.AreEqual(name, board.Name);
            Assert.IsInstanceOfType(board, typeof(IBoard));
        }
    }
}
