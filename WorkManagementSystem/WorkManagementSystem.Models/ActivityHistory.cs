using System;
using System.Collections.Generic;
using System.Text;

namespace WorkManagementSystem.Models
{
    public class ActivityHistory
    {
        public ActivityHistory(string activityMessage)
        {
            this.ActivityMessage = activityMessage;
            this.ActivityTime = DateTime.Now;
        }

        public string ActivityMessage { get; }

        public DateTime ActivityTime { get; }
    }
}
