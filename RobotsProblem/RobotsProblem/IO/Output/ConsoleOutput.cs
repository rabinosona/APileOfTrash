using RobotsProblem.Entities;
using System;
using System.Collections.Generic;

namespace RobotsProblem.IO.Output
{
    class ConsoleOutput : IOutput
    {
        public void PrintRobotsInfo(ICollection<Robot> robots)
        {
            foreach (var robot in robots)
            {
                var lostText = robot.IsLost ? "LOST" : "";

                Console.WriteLine($"{robot.CurrentPosition.X} {robot.CurrentPosition.Y} {robot.CurrentOrientation.ToString()} {lostText}");
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
