using RobotsProblem.Entities;
using RobotsProblem.Entities.Enums;
using System;

namespace RobotsProblem.Operators
{
    interface IRobotOperator
    {
        /// <summary>
        /// Move a number of steps in a specified direction
        /// </summary>
        /// <param name="step"></param>
        /// <param name="position"></param>
        GridPosition MoveInDirection(int step, GridPosition position, Orientation orientation);

        /// <summary>
        /// Turn robot by selected number of degrees.
        /// </summary>
        /// <param name="degree"></param>
        Orientation TurnRobot(Orientation orientation, RotationDegree degree);
    }
}
