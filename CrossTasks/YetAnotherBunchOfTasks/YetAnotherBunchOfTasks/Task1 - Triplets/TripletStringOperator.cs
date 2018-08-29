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

            var maxAmount = 0; // max amount of occurences of the string
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
            // we need to round up the chunk size so we would be able to cover all the string
            // example: 18 chars long, withouth rounding up we would have chunk size of 4,
            // therefore we would be able to track only 16 chars of our string.

            var chunkSize = (int)Math.Ceiling((double)str.Length / (double)MaxCpuCount);
            var threadsCount = MaxCpuCount;

            var charsLeft = str.Length;

            _tasksForTripleting = new Task[threadsCount];

            for (int i = 0; i < threadsCount; i++)
            {
                var temp = i;
                var tempChunk = chunkSize; // those variables are created because of clojures which capture the variables

                if (tempChunk > charsLeft) { tempChunk = charsLeft; } 
                // if the chunk size is bigger than the chars that we have left in our string then the chunksize should have a size of those
                // left symbols

                _tasksForTripleting[i] = new Task(() =>
                {
                    var from = temp * chunkSize; // using chunkSize as we never want to change it for 'from'
                    var to = from + tempChunk; // using tempChunk so we would be able to adjust the 'to' value in edge cases

                    CheckChunk(str, from, to, ct);
                }, ct);

                _tasksForTripleting[i].Start();
                charsLeft -= chunkSize;
            }

            Task.WaitAll(_tasksForTripleting);

        }

        private static void CheckChunk(string str, int from, int to, CancellationToken ct)
        {
            // we need to start from first symbol and end on the str.length - 1 symbol.
            if (to == str.Length) to -= 1;
            if (from == 0) from += 1;

            for (int i = from; i < to; i++)
            {
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

            // we use this thread-safe method to adjust our dictionary so we would add the key
            // if it does not exist or update it if it exists.

            _tripletDictionary.AddOrUpdate(temp, 1, (tmp, occurences) => occurences + 1);

        }
    }
}
