using RobotsProblem.Entities;
using RobotsProblem.IO.Input.Models;

namespace RobotsProblem.IO.Input
{
    interface IInput
    {
        (int, int) ReadGridSize();

        RobotBaseInfo ReadRobotInfo();

        string ReadRobotCommands();

        string ReadKeyboardInput();
    }
}
