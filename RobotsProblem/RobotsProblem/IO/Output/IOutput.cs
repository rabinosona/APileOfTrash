using RobotsProblem.Entities;
using System.Collections.Generic;

namespace RobotsProblem.IO.Output
{
    interface IOutput
    {
        void PrintRobotsInfo(ICollection<Robot> robots);

        void PrintMessage(string message);
    }
}
