using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.CreateCommandsTests
{
    [TestClass]
    public class CreatePersonCommand_Should
    {
        [TestMethod]
        public void SuccessfullyCreatePerson()
        {
            var reader = Substitute.For<IReader>();

            string personName = "Pesho";
            var input = reader.Read().Returns("Pesho");

            var instanceFactory = Substitute.For<IInstanceFactory>();
            var modelsFactory = Substitute.For<IModelsFactory>();

            var db = Substitute.For<IDatabase>();


            IMember currMember = modelsFactory.CreatePerson(personName);

            db.Members.Returns(new List<IMember>());
            instanceFactory.Database.Returns(db);

           // Assert.IsTrue()

        }
    }
}
