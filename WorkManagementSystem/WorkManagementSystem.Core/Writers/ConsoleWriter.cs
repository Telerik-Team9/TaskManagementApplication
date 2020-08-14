using System;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Writers
{
    public class ConsoleWriter : IWriter
    {
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
