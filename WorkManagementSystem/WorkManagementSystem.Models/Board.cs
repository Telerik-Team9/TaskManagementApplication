﻿using System;
using WorkManagementSystem.Models.Abstracts;
using WorkManagementSystem.Models.Common;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidInput, "name"));
                }

                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException(string.Format(ModelsConstants.InvalidTextRange, "name", 5, 10));
                }

                base.Name = value;
            }
        }

    }
}
