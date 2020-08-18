using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.ListCommands;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Common.Enums;
using WorkManagementSystem.Tests.Fakes;

namespace WorkManagementSystem.Tests.Core.Tests.CommandTests.ListCommandsTests
{
    [TestClass]
    public class ListFeedbacksCommand_Should
    {

            [TestMethod]
            [DataRow("New")]
            [DataRow("Unscheduled")]
            [DataRow("Scheduled")]
            [DataRow("Done")]
        public void FilterByStatus(string value)
            {
                //Arrnge
                IInstanceFactory fakeFactory = new FakeInstanceFactory();
                var command = new ListFeedbacksCommand(fakeFactory);
                IList<string> parameters = new List<string>() { "status", value, "" };
                IList<string> result = fakeFactory.Database
                    .Feedbacks
                    .Where(t => t.Status == Enum.Parse<FeedbackStatus>(parameters[1], true))
                    .Select(w => w.PrintInfo())
                    .ToList();
                string expected = string.Join(Environment.NewLine, result);

                //Act
                string actual = command.Execute(parameters);

                //Assert
                Assert.IsTrue(actual.Contains(expected));
            }

            [TestMethod]
            public void SortByTitle()
            {
                //Arrnge
                IInstanceFactory fakeFactory = new FakeInstanceFactory();
                var command = new ListFeedbacksCommand(fakeFactory);
                IList<string> parameters = new List<string>() { "", "", "title" };
                IList<string> result = fakeFactory.Database
                    .Feedbacks
                    .OrderBy(t => t.Title)
                    .Select(w => w.PrintInfo())
                    .ToList();
                string expected = string.Join(Environment.NewLine, result);

                //Act
                string actual = command.Execute(parameters);

                //Assert
                Assert.IsTrue(actual.Contains(expected));
            }
      
            [TestMethod]
            public void SortByRating()
            {
                //Arrnge
                IInstanceFactory fakeFactory = new FakeInstanceFactory();
                var command = new ListFeedbacksCommand(fakeFactory);
                IList<string> parameters = new List<string>() { "", "", "rating" };
                IList<string> result = fakeFactory.Database
                    .Feedbacks
                    .OrderBy(t => t.Rating)
                    .Select(w => w.PrintInfo())
                    .ToList();
                string expected = string.Join(Environment.NewLine, result);

                //Act
                string actual = command.Execute(parameters);

                //Assert
                Assert.IsTrue(actual.Contains(expected));
            }

           [TestMethod]
           public void ThrowWhen_NoAssignedWorkItems()
           {
               //Arrnge
               IInstanceFactory fakeFactory = new FakeInstanceFactory();
               var command = new ListBugsCommand(fakeFactory);
               IList<string> parameters = new List<string>() { "assignee", "Aliii", "" };

               //Act & assert
               Assert.ThrowsException<ArgumentException>(() =>
               {
                   _ = command.Execute(parameters);
               });
           }
    }
}
