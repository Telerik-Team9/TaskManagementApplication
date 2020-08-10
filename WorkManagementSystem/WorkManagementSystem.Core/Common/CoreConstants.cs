using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace WorkManagementSystem.Core.Common
{
    public static class CoreConstants
    {
        // Common
        public const string EnterFollowingParameters = "Please enter the following parameters:";
        public const string Title = "Title: ";
        public const string Description = "Description: ";
        public const string Rating = "Rating: ";
        public const string EnterEnum = "{0} - Choose one of the following: ({1}) or leave this field empty.";
        public const string CreatedWorkItem = "{0} with title '{1}' was created.";
        public const string PressEnterForNewCommand = "Please press \"Enter\" to select a new command.";

        // Member
        public const string EnterMemberDetails = "Please enter member's name and press \"Enter\".";
        public const string MemberAlreadyExistsExcMessage = "Member {0} already exists.";
        public const string CreatedMember = "Member {0} has been created.";
        public const string MemberDoesNotExistExcMessage = "A person with name {0} does not exist in the database.";

        // Team
        public const string NoTeamsInDatabaseExcMessage = "There are currently no teams in the database.";
        public const string SelectTeamToAddBoardTo = "Please select a team to add a new board to:";
        public const string TeamDoesNotExistExcMessage = "The team {0} does not exist.";
        
        // Board
        public const string EnterBoardName = "Please enter board name: ";
        public const string BoardAlreadyExistsExcMessage = "A board with name {0} already exists in team {1}";
        public const string BoardDoesNotExistInTheDatabase = "A board with name {0} does not exist in the database.";
        public const string CreatedBoard = "A board with name '{0}' has been added to {1} team.";
        public const string EnterBoardNameToAddWorkitemTo = "Please select a board to add a {0} to: ";

        // Person
        public const string SelectTeamToAddPersonTo = "Please select a team to add a new person to:";
        public const string PersonIsAlreadyOnTheTeamExcMessage = "{0} is already on {0} team.";
        public const string PersonAddedToATeam = "{0} has been added to {1} team.";




        /*      
                public static IList<string> memberProperties = new List<string>()
                {
                    "Name"
                };

                public static IList<string> commonWorkitemProperties = new List<string>()
                {
                    "Title",
                    "Desctiprtion",
                    "Comments",
                    "History"
                };

                public static IList<string> bugProperties = new List<string>()
                {
                    "Priority",
                    "Severity",
                    "Status",
                    "Assignee"
                };

                public static IList<string> feedbackProperties = new List<string>()
                {
                    "Rating",
                    "Status"
                };

                public static IList<string> storyProperties = new List<string>()
                {
                    "Size",
                    "Status",
                    "Priority",
                    "Assignee"
                };*/

        public static string allCommands =
            "Create commands:" + NewLine +
            " createperson" + NewLine +
            " createteam" + NewLine +
            " createboardinateam" + NewLine +
            " createbug" + NewLine +
            " createfeedback" + NewLine +
            " createstory" + NewLine +
            "Show commands:" + NewLine +
            " showallpeople" + NewLine +
            " showallteams" + NewLine +
            "Add commands:" + NewLine +
            " addpersontoateam" + NewLine +
            "-----------------------------------------------------" + NewLine;


    }
}
