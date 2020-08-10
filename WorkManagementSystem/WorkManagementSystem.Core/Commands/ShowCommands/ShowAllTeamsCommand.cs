using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand(IInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
        }

        public override string Execute()
        {
            if (!this.InstanceFactory.Database.Teams.Any())
            {
                return "There are currently no teams on the list.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var team in this.InstanceFactory.Database.Teams)
            {
                // sb.AppendLine(t.Name);
                sb.AppendLine(team.PrintInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
