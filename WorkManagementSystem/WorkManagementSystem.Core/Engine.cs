using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Readers;
using WorkManagementSystem.Core.Writers;

namespace WorkManagementSystem.Core
{
    public class Engine : IEngine
    {
        private static Engine instance;
        private readonly ICommandManager commandManager;

        private Engine()
        {
            this.commandManager = new CommandManager();
        }

        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }
        private static IReader Reader
        {
            get
            {
                return ConsoleReader.Instance;
            }
        }
        private static IWriter Writer
        {
            get
            {
                return ConsoleWriter.Instance;
            }
        }

        public void Run()
        {
            while (true)
            {
                var commandName = Reader.Read();
                var result = this.Process(commandName);
                this.Print(result);

                Thread.Sleep(6000);
                Writer.Clear();
            }
        }

        private string Process(string commandName)
        {
            try
            {
                ICommand command = this.commandManager.ParseCommand(commandName);
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
            Writer.WriteLine(sb.ToString().Trim());
        }
    }
}
