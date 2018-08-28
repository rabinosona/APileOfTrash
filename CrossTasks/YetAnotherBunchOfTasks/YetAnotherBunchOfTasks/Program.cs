using System;
using System.Threading;
using YetAnotherBunchOfTasks.Task1Triplets;

namespace YetAnotherBunchOfTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var test = "abcabcbacbac";

            var x =  TripletStringOperator.FindMostFrequentTriplet(test, cancellationToken);

            Console.WriteLine(x);

            Console.ReadLine();
        }
    }
}
