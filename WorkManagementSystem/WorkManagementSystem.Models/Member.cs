using System;
using WorkManagementSystem.Models.Abstracts;
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
