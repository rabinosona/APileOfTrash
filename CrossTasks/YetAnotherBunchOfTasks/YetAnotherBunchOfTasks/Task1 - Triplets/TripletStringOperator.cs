using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Concurrent;
using System.Linq;

namespace YetAnotherBunchOfTasks.Task1Triplets
{
    /// <summary>
    /// A class for multi-threaded search of triplets inside a string.
    /// </summary>
    public static class TripletStringOperator
    {
        static Task[] _tasksForTripleting;
        static ConcurrentDictionary<string, int> _tripletDictionary;
        static int MaxCpuCount;

        static TripletStringOperator()
        {
            _tripletDictionary = new ConcurrentDictionary<string, int>();
            MaxCpuCount = Environment.ProcessorCount;
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

            var maxAmount = 0;
            var returnableString = "";

            // first check - to find the maximal amount of occurrences of the one triplet.

            foreach (var pair in _tripletDictionary)
            {
                if (pair.Value > maxAmount)
                {
                    maxAmount = pair.Value;
                }
            }

            foreach (var pair in _tripletDictionary)
            {
                if (pair.Value == maxAmount)
                {
                    returnableString += $"{pair.Key},";
                }
            }

            returnableString.TrimEnd(',');
            returnableString += $"\t{maxAmount}";

            return returnableString;
        }

        private const int MinimalChunkSize = 3;

        private static void FindTriplet(string str, CancellationToken ct)
        {
            var chunkSize = (str.Length + MaxCpuCount - 1) / MaxCpuCount;
            var threadsCount = MaxCpuCount;

            while (chunkSize < MinimalChunkSize)
            {
                threadsCount -= 1;
                chunkSize = (str.Length + threadsCount - 1) / threadsCount; 
            }

            var charsLeft = str.Length;

            _tasksForTripleting = new Task[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {
                var temp = i;
                var tempChunk = chunkSize; // those variables are created because of clojures which capture the variables

                if (tempChunk > charsLeft) { tempChunk = charsLeft; }

                _tasksForTripleting[i] = new Task(() =>
                {
                    var from = temp * tempChunk;
                    var to = from + tempChunk;

                    CheckChunk(str, from, to , ct);
                }, ct);

                _tasksForTripleting[i].Start();
                charsLeft -= chunkSize;
            }

            Task.WaitAll(_tasksForTripleting);

        }

        private static void CheckChunk(string str, int from, int to, CancellationToken ct)
        {
            for (int i = from + 1; i < to - 1; i++)
            { // abcabc
                CheckTriplet(str[i - 1], str[i], str[i + 1]);
            }
        }

        private static void CheckTriplet(char symbolBefore, char supportingSymbol, char symbolAfter)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(symbolBefore); stringBuilder.Append(supportingSymbol); stringBuilder.Append(symbolAfter);

            // we should build a triplet and then check if it exists in a dictionary. if not, we should create a dictionary 
            // pair for it with a value of 1. if it is, we should increment the value for this particular key.

            var temp = stringBuilder.ToString();

            _tripletDictionary.AddOrUpdate(temp, 1, (tmp, occurences) => occurences + 1);

        }
    }
}
