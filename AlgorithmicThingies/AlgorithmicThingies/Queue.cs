using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicThingies
{
    class Queue<T>
    {
        private Stack<T> _firstStack;
        private Stack<T> _queue; // that's the queue

        public void Push(T value)
        {
            if (_firstStack == null)
            {
                _firstStack = new Stack<T>();
                _firstStack.Push(value);

                if (_queue == null)
                {
                    _queue = new Stack<T>();
                }
                _queue.Push(_firstStack.Pop());

                return;
            }

            _firstStack.Push(value);
            _queue.Push(_firstStack.Pop());
        }

        public T Pop()
        {
            return _queue.Pop();
        }
    }

    class QueueTest
    {
        public void RunTest()
        {
            var queue = new Queue<int>();

            queue.Push(3);
            queue.Push(4);
            queue.Push(5);

            Console.WriteLine(queue.Pop());
        }
    }
}
