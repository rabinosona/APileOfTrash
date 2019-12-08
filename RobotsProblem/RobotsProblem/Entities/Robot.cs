using RobotsProblem.Entities.Enums;
using RobotsProblem.Exceptions;
using RobotsProblem.Operators;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Entities
{
    // Didn't implement ICharacter interface in this particular case
    // As the task didn't specify any types of characters except simple robots.

    class Robot
    {
        private readonly IRobotOperator _robotOperator;

        private Orientation _orientation;

        /// <summary>
        /// The current position of the robot.
        /// </summary>
        public GridPosition CurrentPosition { get; set; }

        public bool IsLost { get; set; }

        public Orientation CurrentOrientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                // checking orientation overflow

                if (value > Orientation.West)
                {
                    // take part starting after 0 degrees
                    _orientation = (Orientation)((int)value % Constants.OrientationSides);
                    return;
                }

                if (value < Orientation.North)
                {
                    // works like a previous west check, but
                    // subtracts negative angle from 360 in
                    // order to achieve positive angle.
                    _orientation = (Orientation)(Constants.OrientationSides + (int)value % Constants.OrientationSides);
                    return;
                }

                _orientation = value;
            }
        }

        public Robot(IRobotOperator robotOperator, (int, int) defaultPosition, Orientation defaultOrientation)
        {
            _robotOperator = robotOperator;

            CurrentPosition = new GridPosition
            {
                X = defaultPosition.Item1,
                Y = defaultPosition.Item2
            };

            CurrentOrientation = defaultOrientation;

            _robotOperator.AddRobot(CurrentPosition);
        }

        public void MoveForward()
        {
            if (IsLost) return;

            try
            {
                CurrentPosition = _robotOperator.MoveInDirection(1, CurrentPosition, CurrentOrientation);
            }
            catch (RobotOutOfBoundsException)
            {
                IsLost = true;

                throw;
            }
        }

        public void TurnRight()
        {
            if (IsLost) return;

            CurrentOrientation = _robotOperator.TurnRobot(CurrentOrientation, RotationDegree.Right90);
        }

        public void TurnLeft()
        {
            if (IsLost) return;

            CurrentOrientation = _robotOperator.TurnRobot(CurrentOrientation, RotationDegree.Left90);
        }
    }
}
