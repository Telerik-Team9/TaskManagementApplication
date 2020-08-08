using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models;

namespace WorkManagementSystem.Tests.ModelsTests
{
    [TestClass]
    public class BugShould
    {
        [TestMethod]
        public void ConstructorShould()
        {
            //Arrange
            string expectedTitle = "This is a test title.";
            string expectedDescription = "This is a test desctiption.";

            //Act
            Bug bug = new Bug(expectedTitle, expectedDescription);
            string actualTitle = bug.Title;
            string actualDescription = bug.Description;

            //Assert
            Assert.AreEqual(expectedTitle, actualTitle);
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitleIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Bug bug = new Bug(null, new string('a', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescriptionIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Bug bug = new Bug(new string('a', 11), null);
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitlelengthIsShorter()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Bug bug = new Bug(new string('a', 9), new string('b', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescrtionlengthIsShorter()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Bug bug = new Bug(new string('a', 11), new string('b', 9));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenTitlelengthIsLonger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Bug bug = new Bug(new string('a', 51), new string('b', 11));
            });
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenDescrtionlengthIsLonger()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Bug bug = new Bug(new string('a', 11), new string('b', 501));
            });
        }
    }
}
