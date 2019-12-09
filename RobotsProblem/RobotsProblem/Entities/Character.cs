using RobotsProblem.Entities.Enums;
using RobotsProblem.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Entities
{
    abstract class Character
    {
        private readonly IGrid _grid;

        protected GridPosition _previousPosition;
        protected GridPosition _currentPosition;

        protected Orientation _orientation;

        public bool IsLost { get; set; }

        public Character(IGrid grid)
        {
            _grid = grid;
        }

        public GridPosition CurrentPosition
        {
            get
            {
                return _currentPosition;
            }
            set
            {
                var rollback = _previousPosition;

                _previousPosition = _currentPosition;
                _currentPosition = value;

                try
                {
                    Notify();
                }
                catch (RobotMovedIntoOccupiedCellException)
                {
                    _currentPosition = _previousPosition;
                    _previousPosition = rollback;
                }
                catch (RobotOutOfBoundsException)
                {
                    _currentPosition = _previousPosition;
                    _previousPosition = rollback;

                    throw;
                }
            }
        }
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

        protected void Notify()
        {
            _grid.MarkCellAsOccupied(_previousPosition, _currentPosition);
        }
    }
}
