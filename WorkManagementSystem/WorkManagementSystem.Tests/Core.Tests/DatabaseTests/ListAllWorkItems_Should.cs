using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.DatabaseTests
{
    [TestClass]
    public class ListAllWorkItems_Should
    {
        [TestMethod]
        public void ReturnsNewListOfWorkitems()
        {
            //Arrnage
            IDatabase db = new Database();

            //Act
            var result = db.ListAllWorkitems();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReturnListOfWorkitems()
        {
            //Arrnage
            IDatabase db = new Database();

            //Act
            var result = db.ListAllWorkitems();

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<IWorkItem>));
        }
    }
}
