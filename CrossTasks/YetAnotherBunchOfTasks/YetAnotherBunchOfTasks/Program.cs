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

            Console.WriteLine("Please enter the string (3+ chars long):");
            var str = Console.ReadLine();

            if (str.Length < 3) Environment.Exit(-1);

            var x =  TripletStringOperator.FindMostFrequentTriplet(str, cancellationToken);

            Console.WriteLine(x);

            Console.ReadLine();
        }
    }
}
