using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicThingies.Search
{
    static class BinarySearch
    {
        static public int PerformSearch<T>(T[] array, T requiredValue) where T: IComparable
        {
            if (array.Length == 1)
            {
                if (array[0].CompareTo(requiredValue) == 0) return 0;
                else return -1;
            }

            var left = 0;
            var right = array.Length - 1;
            int middle;

            while (left < right)
            {
                middle = (left + right) / 2;

                if (requiredValue.CompareTo(array[middle]) > 0)
                {
                    left = middle + 1;
                }
                else right = middle;
            }

            if (array[left].CompareTo(requiredValue) == 0) return left;

            return -1;
        }

        public class BinarySearchTest
        {
            public void RunTest()
            {
                int[] array = { 1 };
                var result = PerformSearch(array, 1);
                Console.WriteLine($"The result of the search is: {result}");
            }
        }
    }
}
