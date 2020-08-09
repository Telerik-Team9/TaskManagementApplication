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
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            this.commandManager = new CommandManager();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
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

        public void Run()
        {
            while (true)
            {
                /* Stopwatch sw = new Stopwatch();
                 sw.Start();*/

                var commandName = this.reader.Read();
                var result = this.Process(commandName);
                this.Print(result);

                Thread.Sleep(3000);
                this.writer.Clear();
                //   var result = this.Process(input);

                /* if (input == "exit")
                 {
                     sw.Stop();
                     TimeSpan ts = sw.Elapsed;
                     string elapsedTime = String.Format
                         ("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                     this.writer.WriteLine($"You have been using our application for {elapsedTime} :).");
                     Environment.Exit(0);
                 }*/
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
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
