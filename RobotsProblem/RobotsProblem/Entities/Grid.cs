using RobotsProblem.Entities.Models;
using RobotsProblem.Operators;
using System.Collections.Generic;

namespace RobotsProblem.Entities
{
    class Grid : IGrid
    {
        readonly IGridOperator _gridOperator;

        public Grid((int, int) upperLeftCoordinate, IGridOperator gridOperator)
        {
            _gridOperator = gridOperator;

            InitializeGrid(upperLeftCoordinate);
        }

        public List<List<GridCellInfo>> GridData { get; set; } = new List<List<GridCellInfo>>();

        public GridCellInfo GetCellInfo(GridPosition position)
        {
            return GridData[position.Y][position.X];
        }

        public void MarkCellAsOccupied(GridPosition oldPosition, GridPosition newPosition)
        {
            _gridOperator.OccupyCell(new CellOccupyModel
            {
                OldPosition = oldPosition,
                NewPosition = newPosition,
                GridData = GridData,
                Constraints = new GridConstraints
                {
                    XConstraint = GridData[0].Count - 1,
                    YConstraint = GridData.Count - 1
                }
            });
        }

        private void InitializeGrid((int, int) upperLeftCoordinate)
        {
            for (int i = 0; i <= upperLeftCoordinate.Item2; i++)
            {
                GridData.Add(new List<GridCellInfo>());
                for (int j = 0; j <= upperLeftCoordinate.Item1; j++)
                {
                    GridData[i].Add(new GridCellInfo
                    {
                        IsOccupied = false
                    });
                }
            }
        }
    }
}
