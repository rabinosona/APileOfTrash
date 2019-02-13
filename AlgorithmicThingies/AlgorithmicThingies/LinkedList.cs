using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmicThingies
{

    class LinkedListItem<T>
    {
        public LinkedListItem<T> NextItem { get; set; }
        public LinkedListItem<T> PreviousItem { get; set; }
        public T Value { get; set; }

        public LinkedListItem<T> Append(T value)
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

    class LinkedListTest
    {
        public void RunTest()
        {
            var root = new LinkedListItem<int>()
            {
                Value = 5
            };
            var second = root.Append(2);
            second.Append(3).Append(4);

            root.TraverseLinkedList(root);
            second.Remove(second);
            root.TraverseLinkedList(root);
        }
    }
}
