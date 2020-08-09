using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Core.Common
{
    public static class CoreConstants
    {

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
        };
    }
}
