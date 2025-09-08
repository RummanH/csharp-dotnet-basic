using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CollectionDemo
{
    public static class Collections
    {
        public static void Run()
        {
            // *** # 1. Array. The number of items is locked. | Can modify existing elements by index.
            // A. Using C# 12+ collection expression (new, modern)
            int[] arr1 = [1, 2, 3];
            arr1[2] = 70;
            // Console.WriteLine(arr1);
            // Console.WriteLine(string.Join(", ", arr1));

            // B. Declaring size only (all values default to 0)
            int[] arr2 = new int[3];
            // Console.WriteLine(arr2);
            // Console.WriteLine(string.Join(", ", arr2));

            // C. Declare and assign later
            int[] arr3;
            arr3 = [10, 20, 30];
            // Console.WriteLine(arr3);
            // Console.WriteLine(string.Join(", ", arr3));

            // D. Multidimensional array
            int[,] arr4 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            // Console.WriteLine(arr4);
            // Console.WriteLine(string.Join(", ", arr4));
            // foreach (var item in arr4)
            // {
            //     Console.WriteLine(item);
            // }

            // E. Jagged array (array of arrays)
            int[][] arr5 = [[1, 2], [3, 4, 5]];
            // Console.WriteLine(arr5);
            // foreach (var item in arr5)
            // {
            //     Console.WriteLine(item);
            // }

            // *** # 2. List<T>
            // A. Empty list, then add items
            var numbers1 = new List<int>();
            numbers1.Add(1);
            numbers1.Add(2);
            numbers1.Add(3);

            Console.WriteLine(string.Join(", ", numbers1));

            // B. From an array
            int[] arr = [1, 2, 3];
            var numbers2 = new List<int>(arr);

            // C. Using collection initializer
            var numbers3 = new List<int> { 1, 2, 3 };

            // D. Jagged List (List of Lists)
            var jaggedList = new List<List<int>>
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5 },
    new List<int> { 6, 7, 8, 9 }
};

            // Access element
            Console.WriteLine(jaggedList[0][1]); // 2

            // Modify element
            jaggedList[1][0] = 10;
            Console.WriteLine(jaggedList[1][0]); // 10

            // Add new inner list
            jaggedList.Add(new List<int> { 11, 12 });



            // 3. Dictionary<TKey, TValue>
            var dict = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30
            };
            // Console.WriteLine($"Dictionary: Alice is {dict["Alice"]} years old");

            // 4. HashSet<T>
            var set = new HashSet<int> { 1, 2, 3 };
            set.Add(2);
            // Console.WriteLine("HashSet<T>: " + string.Join(", ", set));

            // 5. SortedSet<T>
            var sortedSet = new SortedSet<int> { 5, 2, 3 };
            sortedSet.Add(1);
            // Console.WriteLine("SortedSet<T>: " + string.Join(", ", sortedSet));

            // 6. Queue<T>
            var queue = new Queue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            // Console.WriteLine("Queue<T> Dequeue: " + queue.Dequeue());

            // 7. Stack<T>
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            // Console.WriteLine("Stack<T> Pop: " + stack.Pop());

            // 8. LinkedList<T>
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(10);
            linkedList.AddLast(20);
            linkedList.AddFirst(5);
            // Console.WriteLine("LinkedList<T>: " + string.Join(", ", linkedList));

            // 9. SortedList<TKey, TValue>
            var sortedList = new SortedList<int, string>
            {
                [2] = "two",
                [1] = "one"
            };
            // Console.WriteLine("SortedList<TKey,TValue>:");
            // foreach (var kv in sortedList)
            //     Console.WriteLine($"{kv.Key}: {kv.Value}");

            // 10. SortedDictionary<TKey, TValue>
            var sortedDict = new SortedDictionary<int, string>
            {
                [3] = "three",
                [1] = "one",
                [2] = "two"
            };
            // Console.WriteLine("SortedDictionary<TKey,TValue>:");
            // foreach (var kv in sortedDict)
            //     Console.WriteLine($"{kv.Key}: {kv.Value}");

            // 11. ConcurrentDictionary<TKey,TValue>
            var concurrentDict = new ConcurrentDictionary<string, int>();
            concurrentDict.TryAdd("user1", 100);
            // Console.WriteLine("ConcurrentDictionary: user1 = " + concurrentDict["user1"]);

            // 12. ImmutableList<T>
            var immutableList = ImmutableList.Create(1, 2, 3);
            var newList = immutableList.Add(4);
            // Console.WriteLine("ImmutableList<T>: " + string.Join(", ", immutableList));
            // Console.WriteLine("ImmutableList<T> after Add: " + string.Join(", ", newList));

            // 13. ObservableCollection<T>
            var observable = new ObservableCollection<string> { "A", "B" };
            // observable.CollectionChanged += (s, e) =>
            //     Console.WriteLine($"ObservableCollection changed: {e.Action}");
            observable.Add("C");

            // 14. ConcurrentBag<T>
            var bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(2);
            // Console.WriteLine("ConcurrentBag<T>: " + string.Join(", ", bag));

            // 15. ImmutableDictionary<TKey, TValue>
            var immutableDict = ImmutableDictionary.CreateBuilder<string, int>();
            immutableDict.Add("x", 1);
            var finalDict = immutableDict.ToImmutable();
            // Console.WriteLine("ImmutableDictionary: x = " + finalDict["x"]);

            // 16. BitArray
            var bits = new BitArray(5);
            bits.Set(0, true);
            // Console.WriteLine("BitArray[0]: " + bits[0]);

            // 17. NameValueCollection
            var nvc = new NameValueCollection();
            nvc.Add("fruit", "apple");
            nvc.Add("fruit", "banana");
            // Console.WriteLine("NameValueCollection fruit: " + string.Join(", ", nvc.GetValues("fruit")));

            // 18. ConcurrentStack<T>
            // Thread-safe LIFO stack
            var concurrentStack = new ConcurrentStack<int>();
            concurrentStack.Push(10);
            concurrentStack.Push(20);
            concurrentStack.TryPop(out int popped);
            // Console.WriteLine("ConcurrentStack<T> popped: " + popped);

            // 19. BlockingCollection<T>
            // Thread-safe producer-consumer collection
            using (var blocking = new BlockingCollection<int>())
            {
                blocking.Add(1);
                blocking.Add(2);
                blocking.CompleteAdding();
                // foreach (var item in blocking)
                //     Console.WriteLine("BlockingCollection<T> item: " + item);
            }
        }
    }
}
