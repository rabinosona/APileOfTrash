using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem.Entities
{
    class GridPosition
    {
        public int X { get; set; }

        public int Y { get; set; }

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
