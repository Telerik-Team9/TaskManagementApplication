using System;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Board : Unit, IBoard
    {
        public Board(string name)
            : base(name)
        {
        }
        public override string Name
        {
            get
            {
                return base.Name;
            }
            protected set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException(); //TODO - Finish ArgException
                }

                base.Name = value;
            }
        }
        protected override string AdditionalInfo()
        {
            throw new NotImplementedException();
        }
    }
}
