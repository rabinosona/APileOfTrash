using RobotsProblem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Operators
{
    interface IGridOperator
    {
        void OccupyCell(CellOccupyModel model);
    }
}
