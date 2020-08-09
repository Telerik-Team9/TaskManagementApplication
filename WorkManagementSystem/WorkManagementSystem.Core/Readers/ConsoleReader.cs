using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Readers
{
    public class ConsoleReader : IReader
    {
        private static ConsoleReader instance = null;
        public static ConsoleReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleReader();
                }

                return instance;
            }
        }
        public string Read()
        {
            return Console.ReadLine();
        }
        
    }
}
