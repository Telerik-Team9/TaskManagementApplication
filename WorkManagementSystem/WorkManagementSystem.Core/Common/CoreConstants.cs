using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace WorkManagementSystem.Core.Common
{
    public static class CoreConstants //TODO: fix constants
    {
        public const string PressEnterForNewCommand = "Press \"Enter\" to select a new command.";

        // Common
        public const string EnterFollowingParameters = "Please enter the following parameters:";
        public const string Title = "Title: ";
        public const string Description = "Description: ";
        public const string Rating = "Rating: ";
        public const string EnterEnum = "{0} - Choose one of the following: ({1}) or leave this field empty.";
        public const string CreatedWorkItem = "{0} with title '{1}' was created.";
        public const string ChooseBoardForWorkitem = "Please select a board to add a {0} to: ";
        public const string NoBoardsForWorkitemsExcMessage = "Cannot add workitem without any boards.";

        // Member
        public const string MemberAlreadyExistsExcMessage = "Member {0} already exists.";
        public const string CreatedMember = "Member {0} has been created.";
        public const string MemberDoesNotExistExcMessage = "A person with name {0} does not exist in the database.";

        // Unit
        public const string EnterUnitName = "Please enter {0}'s name and press \"Enter\".";
        public const string CreatedUnit = "{0} with name '{1}' was created.";

        // Team
        public const string TeamAlreadyExistsExcMessage = "Team {0} already exists.";
        public const string NoTeamsInDatabaseExcMessage = "There are currently no teams in the database.";
        public const string SelectTeamToAddBoardTo = "Please select a team to add a new board to:";
        public const string TeamDoesNotExistExcMessage = "The team {0} does not exist.";

        // Board
        //public const string EnterBoardName = "Please enter board name: ";
        public const string BoardAlreadyExistsExcMessage = "A board with name {0} already exists in team {1}";
        public const string BoardDoesNotExistInTheDatabase = "A board with name {0} does not exist in the database.";
        public const string CreatedBoard = "A board with name '{0}' has been added to {1} team.";

        // Person
        public const string SelectTeamToAddPersonTo = "Please select a team to add a new person to:";
        public const string PersonIsAlreadyOnTheTeamExcMessage = "{0} is already on {1} team.";
        public const string PersonAddedToATeam = "{0} has been added to {1} team.";


        public static readonly string Team9Logo =
            "/$$$$$$$$                                       /$$$$$$  "     + NewLine +
            "|__  $$__/                                      /$$__  $$"     + NewLine +
            "   | $$  /$$$$$$   /$$$$$$  /$$$$$$/$$$$       | $$  \\ $$"    + NewLine +
            "   | $$ /$$__  $$ |____  $$| $$_  $$_  $$      |  $$$$$$$"     + NewLine +
            "   | $$| $$$$$$$$  /$$$$$$$| $$ \\ $$ \\ $$       \\____  $$"  + NewLine +
            "   | $$| $$_____/ /$$__  $$| $$ | $$ | $$       /$$  \\ $$"    + NewLine +
            "   | $$|  $$$$$$$|  $$$$$$$| $$ | $$ | $$      |  $$$$$$/"     + NewLine +
            "   |__/ \\_______/ \\_______/|__/ |__/ |__/       \\______/ ";

        public static readonly string[,] AllCommands =
        {
          /*             Create Commands        Show Commands           Add/Remove Commands             Change Commands             ListCommands    */  
          /* Title */  { "Create",              "Show",                 "Add/Remove",                   "Change",                   "List"          },
                       { "createperson",        "showallpeople",        "addcommenttoworkitem",         "changebugproperty",        "listworkitems" },
                       { "createteam",          "showallteamboards",    "addpersontoteam",              "changefeedbackproperty",   "listbugs"      },
                       { "createboardinteam",   "showallteammembers",   "addworkitemtoperson",          "changestoryproperty",      "listfeedbacks" },
                       { "createbug",           "showallteams",         "removeworkitemfromperson",     "",                         "liststories"   },
                       { "createfeedback",      "showboardactivity",    "",                             "",                         ""              },
                       { "createstory",         "showteamactivity",     "",                             "",                         ""              },
        };
    }
}