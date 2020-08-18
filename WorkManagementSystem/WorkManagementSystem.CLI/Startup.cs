using WorkManagementSystem.Core;
using WorkManagementSystem.Core.Contracts;
using WorkManagementSystem.Core.Factories;

namespace WorkManagementSystem.CLI
{
    public class Startup
    {
        private readonly static IInstanceFactory instanceFactory = new InstanceFactory();
        private readonly static IEngine engine = new Engine(instanceFactory);

        public static void Main()
        {
            engine.Run();
        }
    }
}
