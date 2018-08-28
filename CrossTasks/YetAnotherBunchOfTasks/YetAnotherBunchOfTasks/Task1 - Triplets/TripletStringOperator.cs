using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Concurrent;

namespace YetAnotherBunchOfTasks.Task1Triplets
{
    /// <summary>
    /// A class for multi-threaded search of triplets inside a string.
    /// </summary>
    public static class TripletStringOperator
    {
        static Task[] _tasksForTripleting;
        static ConcurrentDictionary<string, int> _tripletDictionary;

        static object _dictLockObject;

        static TripletStringOperator()
        {
            _tripletDictionary = new ConcurrentDictionary<string, int>();
        }

        /// <summary>
        /// A method which find the most frequent triplet in the string.
        /// </summary>
        /// <returns>The most frequent triplet.</returns>
        /// <param name="str">String.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        public static string FindMostFrequentTriplet(
            string str, CancellationToken cancellationToken)
        {
            FindTriplet(str, cancellationToken);

            Console.WriteLine("Tasks have been completed.");

            Console.WriteLine(_tripletDictionary["abc"]);

            return "";
        }

        private static void FindTriplet(string str, CancellationToken ct)
        {

            int requiredAmountOfThreads = str.Length - 2; // because we need to run from 1 element of array to the last.

            _tasksForTripleting = new Task[requiredAmountOfThreads];

            for (int i = 1; i < requiredAmountOfThreads + 1; i++) // est
            {
                var temp = i;

                _tasksForTripleting[temp - 1] = new Task(() =>
                {
                    CheckTriplet(str[temp - 1], str[temp], str[temp + 1]);
                }, ct);

                if (ct.IsCancellationRequested) break;

                _tasksForTripleting[temp - 1].Start();
            }

            Task.WaitAll(_tasksForTripleting);
        }

        private static void CheckTriplet(char symbolBefore, char supportingSymbol, char symbolAfter)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(symbolBefore); stringBuilder.Append(supportingSymbol); stringBuilder.Append(symbolAfter);

            var temp = stringBuilder.ToString();

                _tripletDictionary.AddOrUpdate(temp, 1, (tmp, occurences) => occurences + 1);

        }
    }
}
