using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.InstanceFactoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateCorrectlyInstanceOfFactory()
        {
            //Arrange and act
            IInstanceFactory factory = new InstanceFactory();

            //Assert
            Assert.IsInstanceOfType(factory, typeof(IInstanceFactory));
        }

        [TestMethod]
        public void CreateCorrectlyInstanceOfDatabase()
        {
            //Arrange and act
            IInstanceFactory factory = new InstanceFactory();

            //Assert
            Assert.IsInstanceOfType(factory.Database, typeof(IDatabase));
        }

        [TestMethod]
        public void CreateCorrectlyInstanceOfModelsFactory()
        {
            //Arrange and act
            IInstanceFactory factory = new InstanceFactory();

            //Assert
            Assert.IsInstanceOfType(factory.ModelsFactory, typeof(IModelsFactory));
        }

        [TestMethod]
        public void CreateCorrectlyInstanceOfCommandManager()
        {
            //Arrange and act
            IInstanceFactory factory = new InstanceFactory();

            //Assert
            Assert.IsInstanceOfType(factory.CommandManager, typeof(ICommandManager));
        }

        [TestMethod]
        public void CreateCorrectlyInstanceOfReader()
        {
            //Arrange and act
            IInstanceFactory factory = new InstanceFactory();

            //Assert
            Assert.IsInstanceOfType(factory.Reader, typeof(IReader));
        }

        [TestMethod]
        public void CreateCorrectlyInstanceOfWriter()
        {
            //Arrange and act
            IInstanceFactory factory = new InstanceFactory();

            //Assert
            Assert.IsInstanceOfType(factory.Writer, typeof(IWriter));
        }
    }
}
