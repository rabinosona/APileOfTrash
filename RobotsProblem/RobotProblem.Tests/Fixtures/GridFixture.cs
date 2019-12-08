using RobotsProblem.Entities;
using RobotsProblem.Operators;

namespace RobotsProblemTest.Fixtures
{
    static class GridFixture
    {
        public static readonly (int, int) DefinedGridSize = (5, 3);

        public static IGridOperator GridOperator { get; private set; }
        public static IGrid Grid { get; private set; }

        public static IRobotOperator RobotOperator { get; private set; }

        static GridFixture()
        {
            InitializeFixture();
        }

        public static void InitializeFixture()
        {
            GridOperator = new GridOperator();
            Grid = new Grid(DefinedGridSize, GridOperator);
            RobotOperator = new RobotOperator(Grid);
        }
    }
}
