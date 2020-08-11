/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.AddCommands
{
    public class AddCommentToWorkItemCommand : Command
    {
        public AddCommentToWorkItemCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()    
        {
            IWorkItem currWorkItem = ChooseWorkItem();
            return AddCommentToWorkItem(currWorkItem);

            *//*this.Writer.WriteLine(this.ListAllWorkItems()); // TODO: Rewrite, so that it uses listclasses

            this.Writer.WriteLine("Do you wish to add a comment to a Bug, Story or Feedback?");
            string workitemType = this.Reader.Read();

            if (workitemType.ToLower() == "bug")
            {
                return AddCommentToBug();
            }

            else if (workitemType.ToLower() == "feedback")
            {
                return AddCommentToFeedback();
            }

            else if (workitemType.ToLower() == "story")
            {
                return AddCommentToStory();
            }


            this.Writer.WriteLine("Select workitem to add a comment to");

            string workitemTitle = this.Reader.Read();

            if (!this.InstanceFactory.Database.Bugs.Any(t => t.Title == workitemTitle) && !this.InstanceFactory.Database.Feedbacks.Any(t => t.Title == workitemTitle) && !this.InstanceFactory.Database.Stories.Any(t => t.Title == workitemTitle))
            {
                throw new ArgumentException(string.Format("Workitem does not exist."));
            }

            IWorkItem currItem = this.InstanceFactory.Database
                .Teams
                .First(t => t.Title == workitemTitle);
            string personName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

            // Check / debug
            if (currentTeam.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.PersonIsAlreadyOnTheTeamExcMessage, personName, teamName));
            }

            IMember member = this.InstanceFactory.Database
                .Members
                .First(p => p.Name == personName);

            currentTeam.AddPerson(member);

            return string.Format(CoreConstants.PersonAddedToATeam, personName, teamName);*//*
            throw new NotImplementedException();

        }

        private IWorkItem ChooseWorkItem()
        {
            *//*var showAllTeamsCommand = new ShowAllTeamsCommand(this.InstanceFactory);
            this.Writer.WriteLine(showAllTeamsCommand.Execute());

            this.Writer.WriteLine("Please enter the team's name to add the person to.");
            string teamName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Teams.Any(team => team.Name == teamName))
            {
                throw new ArgumentException(string.Format(CoreConstants.TeamDoesNotExistExcMessage, teamName));
            }

            ITeam currTeam = this.InstanceFactory.Database
                .Teams
                .First(t => t.Name == teamName);

            return currTeam;*//*
        }

        private string AddCommentToWorkItem(IWorkItem currWorkItem)
        {
            *//*this.Writer.WriteLine(string.Format("Please enter person's name:"));
            string personName = this.Reader.Read();

            if (!this.InstanceFactory.Database.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.MemberDoesNotExistExcMessage, personName));
            }

            // Check / debug
            if (currTeam.Members.Any(p => p.Name == personName))
            {
                throw new ArgumentException(string.Format(CoreConstants.PersonIsAlreadyOnTheTeamExcMessage, personName, currTeam.Name));
            }

            IMember member = this.InstanceFactory.Database.Members
                .First(p => p.Name == personName);

            currTeam.AddPerson(member);

            return string.Format(CoreConstants.PersonAddedToATeam, personName, currTeam.Name);*//*
        }






        *//*        private string ListAllWorkItems()
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("Bugs: ");
                    foreach (var t in this.InstanceFactory.Database.Bugs)
                    {
                        sb.AppendLine(t.Title);
                    }

                    sb.AppendLine("Feedbacks: ");
                    foreach (var t in this.InstanceFactory.Database.Feedbacks)
                    {
                        sb.AppendLine(t.Title);
                    }

                    sb.AppendLine("Stories: ");
                    foreach (var t in this.InstanceFactory.Database.Stories)
                    {
                        sb.AppendLine(t.Title);
                    }

                    return sb.ToString().TrimEnd();
                }*/

        /*        private string AddCommentToBug()
                {
                    if (!this.InstanceFactory.Database.Bugs.Any())
                    {
                        throw new ArgumentException("There are no bugs to add a comment to.");
                    }

                    this.Writer.WriteLine("Enter the Bug's title, to which you wish to add a comment: "); // TODO: Rewrite, so that it uses listclasses
                    string bugTitle = this.Reader.Read();



                }*//*
    }
}
*/