using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Models.Contracts;
using static System.Environment;

namespace WorkManagementSystem.Core.Commands.CreateCommands
{
    public class CreateBoardInTeamCommand : Command
    {
        public CreateBoardInTeamCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ITeam currTeam = this.InstanceFactory.Database.Teams.First(t => t.Name == parameters[0]);

            return CreateBoardInTeam(currTeam, parameters[1]);
        }

        private string CreateBoardInTeam(ITeam currTeam, string boardName)
        {
            if (currTeam.Boards.Any(b => b.Name == boardName))
            {
                throw new ArgumentException(string.Format(CoreConstants.BoardAlreadyExistsExcMessage, boardName, currTeam.Name));
            }

            IBoard currBoard = this.InstanceFactory.ModelsFactory.CreateBoard(boardName);
            currTeam.AddBoard(currBoard);

            this.InstanceFactory.Database.Boards.Add(currBoard);

            string activity = string.Format(CoreConstants.CreatedBoard, boardName, currTeam.Name);

            currBoard.AddActivityLog(activity);

            return activity + NewLine
                + currBoard.PrintInfo();
        }

        public override IList<string> GetUserInput()
        {
            ITeam currTeam = ChooseMethods.ChooseTeam(this.InstanceFactory);

            this.Writer.WriteLine(string.Format(CoreConstants.EnterUnitName, "board"));
            string boardName = this.Reader.Read();

            IList<string> parameters = new List<string>();
            parameters.Add(currTeam.Name);
            parameters.Add(boardName);

            return parameters;
        }
    }
}
