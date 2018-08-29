using System.Collections.Generic;

namespace YetAnotherBunchOfTasks.Task2___Optimal_Way
{
    /*
    В таблице размером 3x3, проставлены в произвольном порядке цифры от 1 до 9.
    Требуется последовательно обойти все элементы этой таблицы таким образом, чтобы получить на выходе максимальное число, 
    сформированное из цифр пройденных ячеек.
    Обход можно начинать с произвольной ячейки, перемещаться можно на соседнюю ячейку только по горизонтали и вертикали, 
    запрещено заходить в одну и ту же ячейку более одного раза.
 
    Входные данные, три строки, с цифрами разделенными пробелами, например
    1 2 3
    8 4 6 - угол или центр, чтобы захватить все числа
    7 5 9

    1 2 3
    4 5 6
    9 8 7
 
    Программа, должна вывести результат в виде числа, например


    987654123
     */

    class OptimalWayLooker
    {
        int [,] _labyrinth = new int[3, 3];
        List<Point> _supportivePoints = new List<Point>()
        {
            new Point { Row = 0, Column = 0,
                AvailableMoveDirections = Point.Direction.Down | Point.Direction.Right },
            new Point { Row = 1, Column = 1, AvailableMoveDirections = Point.Direction.Up | Point.Direction.Down |
                Point.Direction.Left | Point.Direction.Right },
            new Point { Row = 2, Column = 0, AvailableMoveDirections = Point.Direction.Up | Point.Direction.Right },
            new Point { Row = 2, Column = 2, AvailableMoveDirections = Point.Direction.Up | Point.Direction.Left },
            new Point { Row = 0, Column = 2, AvailableMoveDirections = Point.Direction.Down | Point.Direction.Left }
        };

        readonly Point CentralStartingPoint = new Point { Row = 1, Column = 1 };

        Point _startingPoint;

        struct Point
        {
            public int Row { get; set; }
            public int Column { get; set; }

            public enum Direction
            {
                Up = 1,
                Down = 2,
                Left = 4,
                Right = 8
            }

            public Direction AvailableMoveDirections { get; set; }
        }

        public OptimalWayLooker(params string[] arr)
        {
            ParseInput(arr);

            FindOptimalWay();
        }

        // parse three strings into our labyrinth.
        private void ParseInput(string [] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                var temp = arr[i].Split(' ');
                for (int j = 0; j < 3; j++)
                {
                    _labyrinth[i, j] = int.Parse(temp[j]);
                }
            }
        }

        // find optimal way.
        // optimal way - longest...
        private string FindOptimalWay()
        {
            FindSupportivePointForStart();

            if (_startingPoint.dire)

            return "";
        }

        // changes _staringPoint
        private void FindSupportivePointForStart()
        {
            int maxNum = 0;

            foreach (var point in _supportivePoints)
            {
                if (_labyrinth[point.Row, point.Column] > maxNum)
                {
                    maxNum = _labyrinth[point.Row, point.Column];
                    _startingPoint = point;
                }
            }
        }
    }
}
