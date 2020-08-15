using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.WorkItemTests
{
    [TestClass]
    public class Description_Should
    {
        [TestMethod]
        public void ThrownWhen_PassedValueIsNull()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem bug = new Bug("TestBug", null, default, default, new List<string>());
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsEmpty()
        {
            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem story = new Story("TestStory", "           ", default, default, default);
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsShorter()
        {
            //Arrange
            string description = new string('a', 9);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem feedback = new Feedback("TestFeedback", description, 5, default);
            });
        }

        [TestMethod]
        public void ThrowWhen_PassedValueIsLonger()
        {
            //Arrange
            string description = new string('a', 501);

            //Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                IWorkItem bug = new Bug("TestBug", description, default, default, new List<string>());
            });
        }
    }
}
