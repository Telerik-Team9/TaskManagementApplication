﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    class Member : IMember
    {
        // TODO implement
        public string Name => throw new NotImplementedException();

        public IReadOnlyCollection<IWorkItem> WorkItems => throw new NotImplementedException();

        public IReadOnlyCollection<ActivityHistory> ActivityHistory => throw new NotImplementedException();
    }
}
