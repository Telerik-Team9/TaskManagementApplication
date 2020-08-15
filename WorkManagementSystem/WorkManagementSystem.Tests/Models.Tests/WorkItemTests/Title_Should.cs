    using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.WorkItemTests
{
    [TestClass]
    public class Title_Should
    {
        [TestMethod]
        public void ThrownWhen_PassedValueIsNull()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem bug = new Bug(null, "TestBugDescription", default, default, new List<string>());
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsEmpty()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem story = new Story("           ", "TestBugDescription", default, default, default);
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsShorter()
        {
            //Arrange
            string name = new string('a', 9);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem feedback = new Feedback(name, "TestBugDescription", 5, default);
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsLonger()
        {
            //Arrange
            string name = new string('a', 51);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem bug = new Bug(name, "TestBugDescription", default, default, new List<string>());
            });
        }
    }
}
