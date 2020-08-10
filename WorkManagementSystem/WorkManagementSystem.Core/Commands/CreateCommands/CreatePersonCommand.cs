using System;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            this.InstanceFactory.Writer.WriteLine("Please enter member's name and press \"Enter\"");

            string personName = this.InstanceFactory.Reader.Read();

            if (this.InstanceFactory.Database.Members.Any(m => m.Name == personName))
            {
                throw new ArgumentException($"Member {personName} already exists.");
            }

            IMember currentMember = this.InstanceFactory.ModelsFactory.CreatePerson(personName);
            this.InstanceFactory.Database.Members.Add(currentMember);

            return $"Member {currentMember.Name} has been created.{Environment.NewLine}" + currentMember.PrintInfo();
        }
    }
}
