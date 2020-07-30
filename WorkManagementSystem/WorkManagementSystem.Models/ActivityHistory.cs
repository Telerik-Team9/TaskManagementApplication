﻿using System;
using System.Runtime.InteropServices.WindowsRuntime;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class ActivityHistory : IActivityHistory
    {
        // TODO _ PRIOR TO INITIALISATION, A CONSTANT MUST BE PASSED TO THE CONSTRUCTOR
        public ActivityHistory(string activityMessage)
        {
            this.ActivityMessage = activityMessage;
            this.ActivityTime = DateTime.Now;
        }

        public string ActivityMessage { get; }

        public DateTime ActivityTime { get; }

        public string PrintInfo()
        {
            throw new NotImplementedException();
        }
    }
}
