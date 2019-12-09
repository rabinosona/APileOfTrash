using RobotsProblem.Entities;
using RobotsProblem.Entities.Enums;
using RobotsProblem.Exceptions;
using RobotsProblem.Input.Models;
using RobotsProblem.IO.Input;
using RobotsProblem.IO.Input.Models;
using RobotsProblem.IO.Output;
using RobotsProblem.Operators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RobotsProblem.Client
{
    class MarthianClient
    {
        private readonly IInput _input;
        private readonly IOutput _output;

        private IGrid _grid;
        private IRobotOperator _robotOperator;
        private IGridOperator _gridOperator;

        private readonly ICollection<RobotWithCommandSequence> _robots = new List<RobotWithCommandSequence>(); 

        public MarthianClient(IInput input, IOutput output)
        {
            _input = input;
            _output = output;

            InitializeBase();
        }

        /// <summary>
        /// Reads the robots information and command sequences
        /// from input source.
        /// </summary>
        public void InitializeRobots()
        {
            var robotsBaseInfo = new List<RobotBaseInfo>();
            var robotsCommands = new List<string>();

            while (true)
            {
                // we can move these strings to resource file in the future

                _output.PrintMessage("Do you want to add one more robot ? y / n");

                var answer = _input.ReadKeyboardInput();

                if (answer.ToUpper(new CultureInfo(Constants.DefaultCultureName)) == "N")
                {
                    break;
                }

                try
                {
                    robotsBaseInfo.Add(_input.ReadRobotInfo());
                    robotsCommands.Add(_input.ReadRobotCommands());
                }
                catch (ArgumentException ae)
                {
                    _output.PrintMessage(ae.Message);
                }
            }

            for (var i = 0; i < robotsBaseInfo.Count; i++)
            {
                var robotInfo = robotsBaseInfo[i];

                try
                {
                    _robots.Add(
                            new RobotWithCommandSequence
                            {
                                Robot = new Robot(_robotOperator, _grid, (robotInfo.X, robotInfo.Y), PickOrientationByCharacter(robotInfo.Orientation)),
                                CommandSequence = robotsCommands[i]
                            });
                }
                catch (RobotMovedIntoOccupiedCellException)
                {
                    _output.PrintMessage($"Robot already exists at {robotInfo.X} {robotInfo.Y}");
                    continue;
                }
                catch (RobotOutOfBoundsException)
                {
                    _output.PrintMessage($"Can't create robot at {robotInfo.X} {robotInfo.Y}: it's out of grid boundaries.");
                    continue;
                }
                catch (ArgumentException)
                {
                    _output.PrintMessage($"Wrong orientation given for robot at {robotInfo.X} {robotInfo.Y}.");
                }
            }
        }

        public void RunRobotsCommands()
        {
            foreach (var robot in _robots)
            {
                foreach (var command in robot.CommandSequence)
                {
                    try
                    {
                        ProcessCommandForRobot(robot.Robot, command);
                    }
                    catch (RobotOutOfBoundsException)
                    {
                        break;
                    }
                }
            }
        }

        public void PrintCommandsResults()
        {
            _output.PrintRobotsInfo(_robots.Select(r => r.Robot).ToList());
        }

        private void ProcessCommandForRobot(Robot robot, char command)
        {
            switch (char.ToUpper(command, new CultureInfo(Constants.DefaultCultureName)))
            {
                case 'F':
                    robot.MoveForward();
                    break;
                case 'R':
                    robot.TurnRight();
                    break;
                case 'L':
                    robot.TurnLeft();
                    break;
                default:
                    break;
            }
        }

        private void InitializeBase()
        {
            var gridCoordinates = _input.ReadGridSize();

            _gridOperator = new GridOperator();
            _grid = new Grid(gridCoordinates, _gridOperator);
            _robotOperator = new RobotOperator();
        }

        private Orientation PickOrientationByCharacter(string character)
        {
            return character.ToUpper(new CultureInfo(Constants.DefaultCultureName)) switch
            {
                "E" => Orientation.East,
                "S" => Orientation.South,
                "N" => Orientation.North,
                "W" => Orientation.West,
                _ => throw new ArgumentException("Unknown robot orientation."),
            };
        }
    }
}
