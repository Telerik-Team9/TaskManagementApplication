using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand()
        : base() { }

        public override string Execute()
        {
            this.Writer.WriteLine("Please enter member's name and press \"Enter\"");

            string personName = this.Reader.Read();

            if (this.Database.Members.Any(m => m.Name == personName))
            {
                throw new ArgumentException($"Member {personName} already exists.");
            }

            IMember currentMember = this.Factory.CreatePerson(personName);
            this.Database.Members.Add(currentMember);

            return $"Member {currentMember.Name} has been created.{Environment.NewLine}" + currentMember.PrintInfo();
        }
    }
}
