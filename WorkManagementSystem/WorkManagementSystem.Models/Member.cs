using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Member : Unit, IMember 
    {
        public Member(string name)
            : base(name)
        {
        }

        protected override string AdditionalInfo()
        {
            throw new NotImplementedException();
        }
    }
}
