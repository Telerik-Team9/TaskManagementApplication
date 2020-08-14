using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Common
{
    public static class ChooseMethods
    {
        public static ITeam ChooseTeam(IInstanceFactory instances) // CreateBoardInTeam command && AddPersonToTeam
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

        public static IMember ChoosePerson(IInstanceFactory instances)// AddWorkItemtoperson command
        {
            instances.Writer.WriteLine(ListMethods.ListAllUnits(instances, x => "Name: " + x.Name, "member"));

            instances.Writer.WriteLine(NewLine +"Enter person's name.");
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
    }
}
