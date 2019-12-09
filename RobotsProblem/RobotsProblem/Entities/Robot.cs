using RobotsProblem.Entities.Enums;
using RobotsProblem.Exceptions;
using RobotsProblem.Operators;

namespace RobotsProblem.Entities
{
    class Robot : Character
    {
        private readonly IRobotOperator _robotOperator;

        public Robot(IRobotOperator robotOperator, IGrid grid, (int, int) defaultPosition, Orientation defaultOrientation) : base(grid)
        {
            _robotOperator = robotOperator;

            CurrentPosition = new GridPosition
            {
                X = defaultPosition.Item1,
                Y = defaultPosition.Item2
            };

            if (CurrentPosition == null)
            {
                throw new RobotMovedIntoOccupiedCellException();
            }

            CurrentOrientation = defaultOrientation;
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
