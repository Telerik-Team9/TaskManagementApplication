using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Readers;
using WorkManagementSystem.Core.Writers;

namespace WorkManagementSystem.Core
{
    public class Engine : IEngine
    {

        private IReader reader = new ConsoleReader();
        private IWriter writer = new ConsoleWriter();

        public void Run()
        {
            while (true)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var input = this.reader.Read();

                if (input == "exit")
                {
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    string elapsedTime = String.Format
                        ("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    this.writer.WriteLine($"You have been using our application for {elapsedTime} :).");
                    Environment.Exit(0);
                }
            }
        }
    }
}
