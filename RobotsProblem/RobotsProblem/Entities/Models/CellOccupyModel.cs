using RobotsProblem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Entities.Models
{
    class CellOccupyModel
    {
        public GridPosition OldPosition { get; set; }
        
        public GridPosition NewPosition { get; set; }

        public List<List<GridCellInfo>> GridData { get; set; }

        public GridConstraints Constraints { get; set; }
    }
}
