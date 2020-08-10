using System;
using System.Collections.Generic;
using System.Text;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Readers
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
