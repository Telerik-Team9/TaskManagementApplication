using System;
using WorkManagementSystem.Core.Contracts;

namespace WorkManagementSystem.Core.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
