using AlgorithmicThingies.ADT;
using System;
using static AlgorithmicThingies.Search.BinarySearch;

namespace AlgorithmicThingies
{
    class Program
    {

        static void Main(string[] args)
        {
            var queueTest = new QueueTest();
            var stackTest = new StackTest();
            var binarySearchTest = new BinarySearchTest();
            queueTest.RunTest();
            Console.WriteLine("STACK TEST \n ===================");
            stackTest.RunTest();
            Console.WriteLine("BINARY SEARCH TEST \n ===================");
            binarySearchTest.RunTest();
        }
    }


}
