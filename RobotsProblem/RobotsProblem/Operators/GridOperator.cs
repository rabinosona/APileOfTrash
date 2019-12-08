using RobotsProblem.Entities;
using RobotsProblem.Entities.Models;
using RobotsProblem.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Operators
{
    class GridOperator : IGridOperator
    {
        public void OccupyCell(CellOccupyModel model)
        {
            var gridData = model.GridData;

            var (newX, newY) = model.NewPosition;

            CheckBoundaryCrossing(gridData, model.Constraints, (newX, newY));

            // processing another robot in the cell case
            if (gridData[newY][newX].IsOccupied)
            {
                throw new RobotMovedIntoOccupiedCellException();
            }   

            // processing happy path
            gridData[newY][newX].IsOccupied = true;

            if (model.OldPosition != null)
            {
                var (oldX, oldY) = model.OldPosition;
                gridData[oldY][oldX].IsOccupied = false;
            }
        }

        private void CheckBoundaryCrossing(List<List<GridCellInfo>> gridData, GridConstraints constraints, (int, int) newCoordinates)
        {

            var (newX, newY) = newCoordinates;

            // processing out of bounds case
            if (newX > constraints.XConstraint)
            {
                gridData[newY][constraints.XConstraint].IsOccupied = true;

                throw new RobotOutOfBoundsException();
            }

            if (newX < 0)
            {
                gridData[newY][0].IsOccupied = true;

                throw new RobotOutOfBoundsException();
            }

            if (newY > constraints.YConstraint)
            {
                gridData[constraints.YConstraint][newX].IsOccupied = true;

                throw new RobotOutOfBoundsException();
            }

            if (newY < 0)
            {
                gridData[0][newX].IsOccupied = true;

                throw new RobotOutOfBoundsException();
            }
        }
    }
}
