﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Models;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Tests.Models.Tests.BugTests
{
    [TestClass]
    public class ChangePriority_Should
    {
        [TestMethod]
        public void ChangeCorrectlyPriority()
        {
            //Arrange
            Priority priority = Priority.High;
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, Priority.Low, default, steps);

            //Act
            bug.ChangePriority(priority);

            //Assert
            Assert.AreEqual(bug.Priority, priority);
        }

        [TestMethod]
        public void AddHistoryLogWhen_PriorityIsCorrectlyChanged()
        {
            //Arrange
            Priority priority = Priority.High;
            string title = new string('a', 10);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, Priority.Low, default, steps);
            string expected = $"Priority changed from {bug.Priority} to {priority}.";

            //Act
            bug.ChangePriority(priority);

            //Assert
            Assert.IsTrue(bug.HistoryLog.Contains(expected));
        }

        [TestMethod]
        public void ThrowWhen_PriortyIsSameAsPassedValue()
        {
            //Arrange
            Priority priority = Priority.High;
            string title = new string('a', 15);
            string descr = new string('a', 55);
            IList<string> steps = new List<string>() { " ", " " };
            IBug bug = new Bug(title, descr, Priority.High, default, steps);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                bug.ChangePriority(priority);
            });
        }
    }
}




//      this.historyLog.Add($"Priority changed from {oldPriority} to {newPriority}.");


/*public void ChangePriority(Priority newPriority)
{
    if (this.Priority == newPriority)
    {
        throw new ArgumentException($"Priority is already on {this.Priority}.");
    }

    Priority oldPriority = this.Priority;
    this.Priority = newPriority;

    this.historyLog.Add($"Priority changed from {oldPriority} to {newPriority}.");
}*/
