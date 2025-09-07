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
            // 1. Array
            int[] arr = [1, 2, 3];
            Console.WriteLine("Array: " + string.Join(", ", arr));

            // 2. List<T>
            var numbers = new List<int> { 1, 2, 3 };
            numbers.Add(4);
            Console.WriteLine("List<T>: " + string.Join(", ", numbers));

            // 3. Dictionary<TKey, TValue>
            var dict = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30
            };
            Console.WriteLine($"Dictionary: Alice is {dict["Alice"]} years old");

            // 4. HashSet<T>
            var set = new HashSet<int> { 1, 2, 3 };
            set.Add(2);
            Console.WriteLine("HashSet<T>: " + string.Join(", ", set));

            // 5. SortedSet<T>
            var sortedSet = new SortedSet<int> { 5, 2, 3 };
            sortedSet.Add(1);
            Console.WriteLine("SortedSet<T>: " + string.Join(", ", sortedSet));

            // 6. Queue<T>
            var queue = new Queue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            Console.WriteLine("Queue<T> Dequeue: " + queue.Dequeue());

            // 7. Stack<T>
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            Console.WriteLine("Stack<T> Pop: " + stack.Pop());

            // 8. LinkedList<T>
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(10);
            linkedList.AddLast(20);
            linkedList.AddFirst(5);
            Console.WriteLine("LinkedList<T>: " + string.Join(", ", linkedList));

            // 9. SortedList<TKey, TValue>
            var sortedList = new SortedList<int, string>
            {
                [2] = "two",
                [1] = "one"
            };
            Console.WriteLine("SortedList<TKey,TValue>:");
            foreach (var kv in sortedList)
                Console.WriteLine($"{kv.Key}: {kv.Value}");

            // 10. SortedDictionary<TKey, TValue>
            var sortedDict = new SortedDictionary<int, string>
            {
                [3] = "three",
                [1] = "one",
                [2] = "two"
            };
            Console.WriteLine("SortedDictionary<TKey,TValue>:");
            foreach (var kv in sortedDict)
                Console.WriteLine($"{kv.Key}: {kv.Value}");

            // 11. ConcurrentDictionary<TKey,TValue>
            var concurrentDict = new ConcurrentDictionary<string, int>();
            concurrentDict.TryAdd("user1", 100);
            Console.WriteLine("ConcurrentDictionary: user1 = " + concurrentDict["user1"]);

            // 12. ImmutableList<T>
            var immutableList = ImmutableList.Create(1, 2, 3);
            var newList = immutableList.Add(4);
            Console.WriteLine("ImmutableList<T>: " + string.Join(", ", immutableList));
            Console.WriteLine("ImmutableList<T> after Add: " + string.Join(", ", newList));

            // 13. ObservableCollection<T>
            var observable = new ObservableCollection<string> { "A", "B" };
            observable.CollectionChanged += (s, e) =>
                Console.WriteLine($"ObservableCollection changed: {e.Action}");
            observable.Add("C");

            // 14. ConcurrentBag<T>
            var bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(2);
            Console.WriteLine("ConcurrentBag<T>: " + string.Join(", ", bag));

            // 15. ImmutableDictionary<TKey, TValue>
            var immutableDict = ImmutableDictionary.CreateBuilder<string, int>();
            immutableDict.Add("x", 1);
            var finalDict = immutableDict.ToImmutable();
            Console.WriteLine("ImmutableDictionary: x = " + finalDict["x"]);

            // 16. BitArray
            var bits = new BitArray(5);
            bits.Set(0, true);
            Console.WriteLine("BitArray[0]: " + bits[0]);

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
            Console.WriteLine("ConcurrentStack<T> popped: " + popped);

            // 19. BlockingCollection<T>
            // Thread-safe producer-consumer collection
            using (var blocking = new BlockingCollection<int>())
            {
                blocking.Add(1);
                blocking.Add(2);
                blocking.CompleteAdding();
                foreach (var item in blocking)
                    Console.WriteLine("BlockingCollection<T> item: " + item);
            }
        }
    }
}
