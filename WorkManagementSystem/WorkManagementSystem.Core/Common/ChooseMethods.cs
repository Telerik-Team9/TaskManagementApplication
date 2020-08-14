using System;
using System.Linq;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Common
{
    public static class ChooseMethods
    {
        public static ITeam ChooseTeam(IInstanceFactory instances)
        {
            instances.Writer.WriteLine(ListMethods.ListAllTeams(instances, x => "Name: " + x.Name));

            instances.Writer.WriteLine($"Enter the team's name:");
            string teamName = instances.Reader.Read();

            if (!instances.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }

            ITeam currTeam = instances.Database
                .Teams
                .First(t => t.Name == teamName);

            return currTeam;
        }

        public static IMember ChoosePerson(IInstanceFactory instances)
        {
            instances.Writer.WriteLine(ListMethods.ListAllUnits(instances, x => "Name: " + x.Name, "member"));

            instances.Writer.WriteLine(NewLine + "Enter person's name.");
            string personName = instances.Reader.Read();

            if (!instances.Database.Members.Any(person => person.Name == personName))
            {
                throw new ArgumentException("Person does not exist.");
            }

            IMember currPerson = instances.Database
                .Members
                .First(person => person.Name == personName);

            return currPerson;
        }

        public static IBoard ChooseBoard(IInstanceFactory instances)
        {
            if (!instances.Database.Boards.Any())
            {
                throw new ArgumentException("There are no boards.");
            }

            //list teams
            instances.Writer.WriteLine(ListMethods.ListAllTeams(instances, x => "Name: " + x.Name));

            instances.Writer.WriteLine($"Enter team's name:");
            string teamName = instances.Reader.Read();

            if (!instances.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }

            //extract team
            ITeam currTeam = instances.Database
                .Teams
                .First(t => t.Name == teamName);

            instances.Writer.WriteLine(NewLine + string.Format(CoreConstants.ChooseBoardForWorkitem, "workitem"));
            instances.Writer.WriteLine(ListMethods.ListAllUnits(instances, x => "Name: " + x.Name, "board"));

            string boardName = instances.Reader.Read();

            if (!currTeam.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardDoesNotExistInTheDatabase, boardName));
            }

            //return board in a team

            IBoard teamBoard = currTeam
                .Boards
                .FirstOrDefault(b => b.Name == boardName);

            return teamBoard;
        }

        public static IWorkItem ChooseWorkItem(IInstanceFactory instances)
        {
            instances.Writer.WriteLine(ListMethods.ListAllWorkItems(instances, x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title));

            instances.Writer.WriteLine(NewLine + "Enter the workitem's id.");
            string id = instances.Reader.Read();

            if (!instances.Database.ListAllWorkitems().Any(w => w.Id == int.Parse(id)))
            {
                throw new ArgumentException("No Workitem with such Id.");
            }

            IWorkItem currWorkItem = instances.Database.ListAllWorkitems()
                .First(w => w.Id == int.Parse(id));

            return currWorkItem;
        }

        //Make Generic
        public static IStory ChooseStory(IInstanceFactory instances)
        {
            instances.Writer.WriteLine(ListMethods.ListAllWorkItems(instances, x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title, "Story"));

            instances.Writer.Write("Type in the ID of the story you want to change: ");
            string idAsStr = instances.Reader.Read();

            if (!instances.Database.Stories.Any(b => b.Id == int.Parse(idAsStr)))
            {
                throw new ArgumentException("You have entered wrong ID.");
            }

            IStory currStory = instances
                .Database
                .Stories
                .First(b => b.Id == int.Parse(idAsStr));

            return currStory;
        }

        public static IBug ChooseBug(IInstanceFactory instances)
        {
            instances.Writer.WriteLine(ListMethods.ListAllWorkItems(instances, x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title, "Bug"));

            instances.Writer.Write("Type in the ID of the bug you want to change: ");
            string idAsStr = instances.Reader.Read();

            if (!instances.Database.Bugs.Any(b => b.Id == int.Parse(idAsStr)))
            {
                throw new ArgumentException("You have entered wrong ID.");
            }

            IBug currBug = instances
                .Database
                .Bugs
                .First(b => b.Id == int.Parse(idAsStr));

            return currBug;
        }

        public static IFeedback ChooseFeedback(IInstanceFactory instances)
        {
            instances.Writer.WriteLine(ListMethods.ListAllWorkItems(instances, x => "Type: " + x.GetWorkItemType() + " | Id: " + x.Id + " | Title: " + x.Title, "Feedback"));

            instances.Writer.Write("Type in the ID of the feedback you want to change: ");
            string idAsStr = instances.Reader.Read();

            if (!instances.Database.Feedbacks.Any(b => b.Id == int.Parse(idAsStr)))
            {
                throw new ArgumentException("You have entered wrong ID.");
            }

            IFeedback currFeedback = instances
                .Database
                .Feedbacks
                .First(b => b.Id == int.Parse(idAsStr));

            return currFeedback;
        }
    }
}
