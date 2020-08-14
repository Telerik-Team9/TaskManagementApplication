using System;
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
            if (typeOfUnit == "member")
            {
                if (!instances.Database.Members.Any())
                {
                    throw new ArgumentException("No members in database.");
                }

                return string.Join(Environment.NewLine, instances.Database.Members.Select(criteria));
            }

            else if (typeOfUnit == "board")
            {
                if (!instances.Database.Boards.Any())
                {
                    throw new ArgumentException("No boards in database.");
                }

                return string.Join(Environment.NewLine, instances.Database.Boards.Select(criteria));
            }

            else
            {
                throw new ArgumentException("Invalid unit.");
            }
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
