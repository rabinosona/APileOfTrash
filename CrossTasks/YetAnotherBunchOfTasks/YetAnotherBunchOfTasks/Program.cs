using System;
using System.Threading;
using YetAnotherBunchOfTasks.Task1Triplets;
using YetAnotherBunchOfTasks.Task2___Optimal_Way;

namespace YetAnotherBunchOfTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var strArr = new string[3];

            for (int i = 0; i < 3; i++)
            {
                strArr[i] = Console.ReadLine();
            }

            OptimalWayLooker waySearch = new OptimalWayLooker(strArr);

            Console.ReadLine();
        }
    }
}
