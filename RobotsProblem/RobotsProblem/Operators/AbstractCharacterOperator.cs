using RobotsProblem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Operators
{
    // Maybe in the future we would like to add more characters to our application?

    /// <summary>
    /// A base character operator with a Grid notification system.
    /// </summary>
    abstract class AbstractCharacterOperator
    {
        private readonly IGrid _grid;

        private Stack<GridPosition> PositionStack = new Stack<GridPosition>();

        public AbstractCharacterOperator(IGrid grid)
        {
            _grid = grid;
        }

        protected void AssignNewPosition(GridPosition newPosition)
        {
            PositionStack.Push(newPosition);
        }

        protected void PerformPositionCleanup()
        {
            PositionStack.Clear();
        }

        protected void Notify()
        {
            var currentPosition = PositionStack.Pop();

            GridPosition previousPosition = null;

            if (PositionStack.Count != 0)
            {
                previousPosition = PositionStack.Pop();
            }

            _grid.MarkCellAsOccupied(previousPosition, currentPosition);

            PositionStack.Push(currentPosition);
        }
    }
}
