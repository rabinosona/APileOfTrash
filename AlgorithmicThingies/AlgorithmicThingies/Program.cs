using System;
using System.Collections.Generic;

namespace AlgorithmicThingies
{
    class Program
    {

        static void Main(string[] args)
        {
            var queueTest = new QueueTest();
            var stackTest = new StackTest();
            queueTest.RunTest();
            Console.WriteLine("STACK TEST \n ===================");
            stackTest.RunTest();
        }
    }
}
