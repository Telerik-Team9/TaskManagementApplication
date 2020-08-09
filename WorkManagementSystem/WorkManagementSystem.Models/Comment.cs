using System;
using WorkManagementSystem.Models.Common;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Models
{
    public class Comment : IComment
    {
        private string message; //TODO - discuss 

        public Comment(string message, IMember author)
        {
            this.Message = message;
            this.Author = author; 
        }

        public IMember Author { get; set; }

        public string Message
        {
            get
            {
                return this.message;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidInput, "comment"));
                }

                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterRange, "comment", 2, 50));
                }

                this.message = value;
            }
        }

        public string PrintInfo()
        {
            return $"{this.Author.Name}: {this.Message}";
        }
    }
}
