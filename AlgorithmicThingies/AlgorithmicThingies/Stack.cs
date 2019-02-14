using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicThingies
{
    class Stack<T>
    {
        private LinkedList<T> _stackList;

        public void Push(T value)
        {
            if (_stackList == null)
            {
                _stackList = new LinkedList<T>(new LinkedListItem<T>
                {
                    Value = value
                });

                return;
            }

            _stackList.AddLast(value);
        }

        public T Pop()
        {
            var result = _stackList.LastItem.Value;
            _stackList.Remove(_stackList.LastItem);

            return result;
        }

        public T Top()
        {
            return _stackList.LastItem.Value;
        }
    }

    class StackTest
    {
        public void RunTest()
        {
            var stack = new Stack<int>();

            stack.Push(3);
            stack.Push(7);
            stack.Push(12);
            stack.Push(561);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Top());
        }
    }
}
