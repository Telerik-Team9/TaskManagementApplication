using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.FactoriesTests.ModelsFactoryTests
{
    [TestClass]
    public class CreateTeam_Should
    {
        [TestMethod]
        public void CreateTeamWhen_ValidValuesArePassed()
        {
            //Arrange
            string name = new string('a', 7);
            IModelsFactory factory = new ModelsFactory();

            //Act
            ITeam team = new Team(name);

            //Assert
            Assert.AreEqual(name, team.Name);
            Assert.IsInstanceOfType(team, typeof(ITeam));
        }
    }
}
