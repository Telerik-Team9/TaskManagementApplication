using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Common;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core
{
    public class Engine : IEngine
    {
        public Engine(IInstanceFactory instanceFactory)
        {
            this.InstanceFactory = instanceFactory;
        }

        public IInstanceFactory InstanceFactory { get; }

        public IReader Reader { get => this.InstanceFactory.Reader; }

        public IWriter Writer { get => this.InstanceFactory.Writer; }

        public void Run()
        {
            while (true)
            {
                //Thread.Sleep(3000);
                this.Writer.WriteLine(CoreConstants.allCommands);

                var commandName = this.Reader.Read();
                var result = this.Process(commandName);
                this.Print(result);

                this.Writer.WriteLine(CoreConstants.PressEnterForNewCommand);
                this.Reader.Read();
                this.Writer.Clear();
            }
        }

        private string Process(string commandName)
        {
            try
            {
                ICommand command = this.InstanceFactory.CommandManager.ParseCommand(commandName, this.InstanceFactory);
                IList<string> parameters = command.GetUserInput();
                string result = command.Execute(parameters);

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
            sb.AppendLine("*****************************");
            this.InstanceFactory.Writer.WriteLine(sb.ToString());
        }
    }
}
