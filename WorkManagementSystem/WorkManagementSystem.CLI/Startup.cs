using System;
using System.Buffers;
using WorkManagementSystem.Core;

namespace WorkManagementSystem.CLI
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
