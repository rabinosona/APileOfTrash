﻿using RobotsProblem.Entities;
using RobotsProblem.Entities.Enums;
using RobotsProblem.Exceptions;

namespace RobotsProblem.Operators
{
    class RobotOperator : AbstractCharacterOperator, IRobotOperator
    {
        public RobotOperator(IGrid grid) : base(grid)
        {

        }

        /// <summary>
        /// Add robot to the map, notify grid about new robot on a field.
        /// </summary>
        /// <param name="position"></param>
        public void AddRobot(GridPosition position)
        {
            AssignNewPosition(position);
            Notify();
        }

        /// <summary>
        /// Move in selected direction, notify grid about robot movement.
        /// </summary>
        /// <param name="step"></param>
        /// <param name="position"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public GridPosition MoveInDirection(int step, GridPosition position, Orientation orientation)
        {
            var movements = ComputeMovement(step, orientation);

            var newPosition = new GridPosition
            {
                X = position.X + movements.Item1,
                Y = position.Y + movements.Item2
            };

            try
            {
                AssignNewPosition(newPosition);

                Notify();
            }
            catch (RobotMovedIntoOccupiedCellException)
            {
                return position;
            }
            catch (RobotOutOfBoundsException)
            {
                PerformPositionCleanup();

                throw;
            }

            return newPosition;
        }

        /// <summary>
        /// Turn robot by selected number of degrees.
        /// </summary>
        /// <param name="degree"></param>
        public Orientation TurnRobot(Orientation orientation, RotationDegree degree)
        {
            return orientation += (int) degree;
        }

        /// <summary>
        /// Computes x and y steps using current step and the robot orientation.
        /// </summary>
        /// <param name="step"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        private (int, int) ComputeMovement(int step, Orientation orientation)
        {
            return orientation switch
            {
                Orientation.East => (step, 0),
                Orientation.West => (-step, 0),
                Orientation.North => (0, step),
                Orientation.South => (0, -step),
                _ => (0, 0),
            };
        }
    }
}
