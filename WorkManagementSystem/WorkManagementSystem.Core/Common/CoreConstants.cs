using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;

namespace WorkManagementSystem.Core.Common
{
    public static class CoreConstants
    {
        public const string EnterEnum = "{0} - Choose one of the following: ({1}) or leave this field empty.";
        public const string CreatedWorkItem = "{0} with title '{1}' was created.";
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
