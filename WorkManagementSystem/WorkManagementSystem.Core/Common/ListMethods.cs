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
    }
}
