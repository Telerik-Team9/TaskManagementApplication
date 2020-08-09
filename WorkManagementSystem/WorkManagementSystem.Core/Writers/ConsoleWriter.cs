using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Writers
{
    class ConsoleWriter : IWriter
    {

        private static ConsoleWriter instance = null;

        public static ConsoleWriter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleWriter();
                }

                return instance;
            }
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
