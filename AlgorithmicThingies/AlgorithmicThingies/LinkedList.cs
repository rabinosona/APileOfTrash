using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicThingies
{

    public class LinkedListItem<T>
    {
        public LinkedListItem<T> NextItem { get; set; }
        public LinkedListItem<T> PreviousItem { get; set; }
        public T Value { get; set; }

        public LinkedListItem<T> Append(ref T value)
        {
            NextItem = new LinkedListItem<T>
            {
                PreviousItem = this,
                Value = value
            };

            return NextItem;
        }

        public LinkedListItem<T> MoveNext()
        {
            if (NextItem != null) return NextItem;
            Console.WriteLine($"Can obtain next element of {Value}");
            return null;
        }

        public void ShowItemInfo()
        {
            Console.WriteLine($"The item's value is {Value}");
            if (NextItem != null) Console.WriteLine($"The next item's value is {NextItem.Value}");
            if (PreviousItem != null) Console.WriteLine($"The previous item's value is {PreviousItem.Value}");
        }

        public LinkedListItem<T> Remove(LinkedListItem<T> item)
        {
            item.PreviousItem.NextItem = item.NextItem;
            item.NextItem.PreviousItem = item.PreviousItem;
            item.NextItem = item.NextItem.NextItem;
            item = item.NextItem;
            return item;
        }
        public void TraverseLinkedList<T>(LinkedListItem<T> item)
        {
            if (item.Value != null)
                Console.WriteLine(item.Value);
            if (item.NextItem != null)
                TraverseLinkedList(item?.NextItem);
        }
    }

    public class LinkedList<T>
    {
        public LinkedListItem<T> CurrentItem { get; set; }

        private LinkedListItem<T> _firstItem;
        private LinkedListItem<T> _lastItem;

        public LinkedList(LinkedListItem<T> item)
        {
            _firstItem = item;
            _lastItem = item;
        }

        public void ShowAll()
        {
            var root = _firstItem;
            var counter = 0;

            while (true)
            {
                if (root == null)
                    break;
                counter++;

                Console.WriteLine($"Element #{counter}");
                if (root.Value != null)
                    Console.WriteLine($"{root.Value}");
                root = root.NextItem;
            }
        }

        public void AddFirst(T value)
        {
            AddBefore(_firstItem, value);
        }

        public void AddLast(T value)
        {
            AddAfter(_lastItem, value);
        }

        public LinkedListItem<T> Find(T value)
        {
            var root = _firstItem;

            do
            {
                if (root.Value.Equals(value)) return root;
                else root = root.NextItem;
            } while (root.NextItem != null);

            return null;
        }

        public void AddBefore(LinkedListItem<T> item, T value)
        {
            var previousItem = new LinkedListItem<T>()
            {
                Value = value
            };

            previousItem.NextItem = item;

            if (item.PreviousItem != null)
            {
                previousItem.PreviousItem = item.PreviousItem;

                item.PreviousItem.NextItem = previousItem;
                item.PreviousItem = previousItem;
            }
            else
            {
                item.PreviousItem = previousItem;
                _firstItem = item.PreviousItem;
            }
        }

        public void AddAfter(LinkedListItem<T> item, T value)
        {
            var nextItem = new LinkedListItem<T>()
            {
                Value = value
            };

            nextItem.PreviousItem = item;

            if (item.NextItem != null)
            {
                nextItem.NextItem = item.NextItem;

                item.NextItem.PreviousItem = nextItem;
                item.NextItem = nextItem;
            }
            else
            {
                item.NextItem = nextItem;
                _lastItem = item.NextItem;
            }
        }
    }

    class LinkedListTest
    {
        public void RunTest()
        {
            var list = new LinkedList<int>(new LinkedListItem<int>()
            {
                Value = 5
            });
            var item = list.Find(5);
            list.AddAfter(item, 7);
            list.AddFirst(782);
            list.AddLast(52352);
            item = list.Find(782);
            list.AddAfter(item, 568);
            list.ShowAll();
        }
    }
}
