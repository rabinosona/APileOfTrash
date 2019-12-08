using RobotsProblem.IO.Input.Models;
using System;
using System.Globalization;

namespace RobotsProblem.IO.Input
{
    class ConsoleInput : IInput
    {
        public (int, int) ReadGridSize()
        {
            Console.WriteLine("Please enter the grid size.");

            var gridSizeInfo = Console.ReadLine().Split(' ');

            if (gridSizeInfo.Length == 2)
            {
                return ParseCoordinates(gridSizeInfo);
            }

            throw new ArgumentException("Grid size string should contain two numbers.");
        }

        public RobotBaseInfo ReadRobotInfo()
        {
            Console.WriteLine("Please enter the robot characteristics. \n" +
                              "Robot coordinates and its orientation.");

            var robotInfo = Console.ReadLine().Split(' ');

            if (robotInfo.Length == 3)
            {
                var (x, y) = ParseCoordinates(robotInfo);

                if (robotInfo[2].Length != 1 || !Constants.AcceptableOrientations.Contains(robotInfo[2].ToUpper(new CultureInfo(Constants.DefaultCultureName))))
                {
                    throw new ArgumentException("The robot orientation is not valid.");
                }

                return new RobotBaseInfo
                {
                    X = x,
                    Y = y,
                    Orientation = robotInfo[2]
                };
            }

            throw new ArgumentException("Robot information should contain its coordinates and orientation.");
        }

        public string ReadRobotCommands()
        {
            Console.WriteLine("Please enter the robot set of commands (conjoined)");

            var instructions = Console.ReadLine();

            if (instructions.Length > 100)
            {
                throw new ArgumentException("The instruction must be no longer than 100 characters in length.");
            }

            return instructions;
        }

        private (int, int) ParseCoordinates(string[] coordinatesString)
        {
            if (int.TryParse(coordinatesString[0], out int x) && int.TryParse(coordinatesString[1], out int y))
            {
                if (x > 50 || y > 50)
                {
                    throw new ArgumentException("One of the coordinates entered is higher than 50.");
                }

                return (x, y);
            }

            throw new ArgumentException("One of the coordinates entered is not a number.");
        }

        public string ReadKeyboardInput()
        {
            return Console.ReadLine();
        }
    }
}
