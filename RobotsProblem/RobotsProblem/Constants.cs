using System;
using System.Collections.Generic;
using System.Text;

namespace RobotsProblem
{
    // that would be a best practice to put it in some config file,
    // but for such a small project the static class is pretty much OK.
    public static class Constants
    {
        public const int OrientationSides = 4;

        public static readonly List<string> AcceptableOrientations = new List<string>
        {
            "E", "S", "N", "W"
        };

        public const string DefaultCultureName = "en-US";
    }
}
