/*using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core.Commands.Abstracts
{
    public abstract class ListCommand : Command
    {
        protected ListCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        protected Func<IWorkItem, bool> GetWorkItemType(string inputType)
            => inputType switch
            {
                "bug" => x => x is IBug,
                "feedback" => x => x is IFeedback,
                "story" => x => x is IStory,
                
                _ => throw new ArgumentException("Invalid type.")
            };

        protected Func<IWorkItem, bool> GetStatusFilter(string workitemType, string inputStatus)
        {
            if (workitemType == "bug")
            {
                return inputStatus switch
                {
                    "bug" => x => x is IBug,
                    "feedback" => x => x is IFeedback,
                    "story" => x => x is IStory,

                    _ => throw new ArgumentException("Invalid status.")
                };
            }

            else if ()



        }



        // listallworkitems 
        // listallbugs
        // listallfeedbacks
        // listallstories

        // Filter by status? ( Active, Fixed )
        // Filter by assignee? ( name )
        // Sort by? ( title/priority/severity/size/rating ) in order ( asc / desc )?


    }
}
*/