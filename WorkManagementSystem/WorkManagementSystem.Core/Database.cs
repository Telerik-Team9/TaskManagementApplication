using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;

namespace WorkManagementSystem.Core
{
    public class Database : IDatabase
    {
        private readonly List<ITeam> teams = new List<ITeam>();
        private readonly List<IMember> members = new List<IMember>();
        private readonly List<IBoard> boards = new List<IBoard>();
        private readonly List<IWorkItem> workItems = new List<IWorkItem>();


        private static IDatabase instance = null;

        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }

        public IList<ITeam> Teams
        {
            get
            {
                return this.teams;
            }
        }

        public IList<IMember> Members
        {
            get
            {
                return this.members;
            }
        }

        public IList<IBoard> Boards
        {
            get
            {
                return this.boards;
            }
        }

        public IList<IWorkItem> WorkItems
        {
            get
            {
                return this.workItems;
            }
        }
    }
}
