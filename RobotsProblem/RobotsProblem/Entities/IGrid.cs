using System.Runtime.CompilerServices;

namespace RobotsProblem.Entities
{
    interface IGrid
    {
        void MarkCellAsOccupied(GridPosition oldPosition, GridPosition newPosition);

        GridCellInfo GetCellInfo(GridPosition position);
    }
}
