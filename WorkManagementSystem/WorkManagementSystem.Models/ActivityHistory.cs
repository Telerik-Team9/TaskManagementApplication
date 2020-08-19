using System;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    internal class ActivityHistory : IActivityHistory
    {
        private static string DateFormat = "[yyyy-MM-dd|HH:mm]";

        internal ActivityHistory(string activityMessage)
        {
            this.ActivityMessage = activityMessage;
            this.ActivityTime = DateTime.Now;
        }

        public string ActivityMessage { get; }

        public DateTime ActivityTime { get; }

        public string PrintInfo()
        {
            return $"{this.ActivityTime.ToString(DateFormat)} | {this.ActivityMessage}";
        }
    }
}
