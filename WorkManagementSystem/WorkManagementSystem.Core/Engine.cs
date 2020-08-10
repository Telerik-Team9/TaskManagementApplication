using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Readers;
using WorkManagementSystem.Core.Writers;

namespace WorkManagementSystem.Core
{
    public class Engine : IEngine
    {
        private IInstanceFactory instanceFactory;

        public Engine(IInstanceFactory instanceFactory)
        {
            this.InstanceFactory = instanceFactory;
        }

        public IInstanceFactory InstanceFactory
        {
            get => instanceFactory;

            private set
            {
                this.instanceFactory = value;
            }
        }

        public void Run()
        {
            while (true)
            {
                this.InstanceFactory.Writer.WriteLine(CoreConstants.allCommands);
                this.InstanceFactory.Writer.WriteLine("Please select a command.");

                var commandName = this.InstanceFactory.Reader.Read();
                var result = this.Process(commandName);
                this.Print(result);

                Thread.Sleep(3000);
                this.InstanceFactory.Writer.Clear();
            }
        }

        private string Process(string commandName)
        {
            try
            {
                ICommand command = this.InstanceFactory.CommandManager.ParseCommand(commandName, this.InstanceFactory);
                string result = command.Execute();

                return result.Trim();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return $"ERROR: {e.Message}";
            }
        }
        private void Print(string commandResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(commandResult);
            sb.AppendLine("####################");
            this.InstanceFactory.Writer.WriteLine(sb.ToString().Trim());
        }
    }
}
