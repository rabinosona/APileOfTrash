using RobotsProblem.Client;
using RobotsProblem.IO.Input;
using RobotsProblem.IO.Output;
using System.Runtime.CompilerServices;

// make our inner classes visible to test.
[assembly: InternalsVisibleToAttribute("RobotProblem.Tests")]

namespace RobotsProblem
{
    class Program
    {
        static void Main()
        {
            // initialize

            IInput input = new ConsoleInput();
            IOutput output = new ConsoleOutput();

            var client = new MarthianClient(input, output);

            client.InitializeRobots();
            client.RunRobotsCommands();

            client.PrintCommandsResults();
        }
    }
}
