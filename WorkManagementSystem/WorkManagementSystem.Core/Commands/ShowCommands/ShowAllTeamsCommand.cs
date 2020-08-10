using System.Linq;
using System.Text;
using WorkManagementSystem.Core.Commands.Abstracts;

namespace WorkManagementSystem.Core.Commands.ShowCommands
{
    public class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand()
        {
        }

        public override string Execute()
        {
            if (!this.Database.Teams.Any())
            {
                return "There are currently no teams on the list.";
            }

            StringBuilder sb = new StringBuilder();

            foreach (var t in this.Database.Teams)
            {
                // sb.AppendLine(t.Name);
                sb.AppendLine(t.PrintInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
