using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Common
{
    public static class ListMethods
    {
        public static string ListAllTeams(IInstanceFactory instances, Func<ITeam, string> criteria)
        {
            if (!instances.Database.Teams.Any())
            {
                throw new ArgumentException("No teams in database.");
            }

            return string.Join(Environment.NewLine, instances.Database.Teams.Select(criteria));
        }

        public static string ListAllUnits(IInstanceFactory instances, Func<IUnit, string> criteria, string typeOfUnit)
        {
            return typeOfUnit switch
            {
                "member" => ListAllMembers(instances, criteria),
                "board" => ListAllBoards(instances, criteria),

                _ => throw new ArgumentException("Invalid unit.")
            };
        }

        // TODO: CHoose board from a team, not from DB!!
        private static string ListAllBoards(IInstanceFactory instances, Func<IUnit, string> criteria)
        {
            if (!instances.Database.Boards.Any())
            {
                throw new ArgumentException("No boards in database.");
            }

            return string.Join(Environment.NewLine, instances.Database.Boards.Select(criteria));
        }

        private static string ListAllMembers(IInstanceFactory instances, Func<IUnit, string> criteria)
        {
            if (!instances.Database.Members.Any())
            {
                throw new ArgumentException("No members in database.");
            }

            return string.Join(Environment.NewLine, instances.Database.Members.Select(criteria));
        }

        public static string ListAllWorkItems(IInstanceFactory instances, Func<IWorkItem, string> criteria)
        {
            var workitems = instances.Database.ListAllWorkitems();

            if (!workitems.Any())
            {
                throw new ArgumentException("No workitems in database.");
            }

            return string.Join(Environment.NewLine, workitems.Select(criteria));
        }

        public static string ListAllWorkItems(IInstanceFactory instances, Func<IWorkItem, string> criteria, string typeOfWorkItem)
        {
            return typeOfWorkItem switch
            {
                "Bug" => ListAllBugs(instances, criteria),
                "Feedback" => ListAllFeedbacks(instances, criteria),
                "Stories" => ListAllStories(instances, criteria),

                _ => throw new ArgumentException("Invalid workitem type.")
            };
        }
       
        private static string ListAllStories(IInstanceFactory instances, Func<IWorkItem, string> criteria)
        {
            var stories = new List<IStory>(instances.Database.Stories);

            if (!stories.Any())
            {
                throw new ArgumentException("No workitems in database.");
            }

            return string.Join(Environment.NewLine, stories.Select(criteria));
        }

        private static string ListAllBugs(IInstanceFactory instances, Func<IWorkItem, string> criteria)
        {
            var bugs = new List<IBug>(instances.Database.Bugs);

            if (!bugs.Any())
            {
                throw new ArgumentException("No workitems in database.");
            }

            return string.Join(Environment.NewLine, bugs.Select(criteria));
        }

        private static string ListAllFeedbacks(IInstanceFactory instances, Func<IWorkItem, string> criteria)
        {
            var feedbacks = new List<IFeedback>(instances.Database.Feedbacks);

            if (!feedbacks.Any())
            {
                throw new ArgumentException("No workitems in database.");
            }

            return string.Join(Environment.NewLine, feedbacks.Select(criteria));
        }

    }
}
