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










            // *** # 2. List<T>. Can modify existing elements by index. | Can add or remove items. | Can be accessed by index.
            // A. Empty list, then add items
            var numbers1 = new List<int>();
            numbers1.Add(1);
            numbers1.Add(2);
            numbers1.Add(3);
            // Console.WriteLine(numbers1);
            // Console.WriteLine(string.Join(", ", numbers1));

            // B. From an array
            int[] arr = [1, 2, 3];
            var numbers2 = new List<int>(arr);
            // Console.WriteLine(numbers2);
            // Console.WriteLine(string.Join(", ", numbers2));

            // C. Using collection initializer
            var numbers3 = new List<int> { 1, 2, 3 };
            // Console.WriteLine(numbers3);
            // Console.WriteLine(string.Join(", ", numbers3));

            // D. Jagged List (List of Lists)
            var jaggedList = new List<List<int>>
            {
                new() { 1, 2, 3 },
                new() { 4, 5 },
                new() { 6, 7, 8, 9 }
            };
            jaggedList[1][0] = 10;
            jaggedList.Add([11, 12]);
            // Console.WriteLine(jaggedList);
            // Console.WriteLine(jaggedList[0][1]);
            // Console.WriteLine(jaggedList[1][0]);










            // *** # 3. Dictionary<TKey, TValue>. Can modify existing elements by key access. | Can add or remove items. | Can't be accessed by index.
            // A. Using collection initializer
            var dict1 = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30
            };
            dict1.Add("Rumman", 27);
            // Console.WriteLine(dict1);
            // Console.WriteLine(string.Join(", ", dict1));

            // B. Empty dictionary, then add items
            var dict2 = new Dictionary<string, string>();
            dict2.Add("USA", "Washington DC");
            dict2.Add("France", "Paris");
            dict2["Rumman"] = "Dhaaka";
            // Console.WriteLine(dict2);
            // Console.WriteLine(string.Join(", ", dict2));


            // C. From another dictionary (copy constructor)
            var dict3 = new Dictionary<string, int>(dict1);
            // Console.WriteLine(dict3);
            // Console.WriteLine(string.Join(", ", dict3));

            // D. Accessing keys and values
            // foreach (var key in dict1.Keys)
            //     Console.WriteLine($"Key: {key}");
            // foreach (var value in dict1.Values)
            //     Console.WriteLine($"Value: {value}");

            // E. TryGetValue to safely access
            // if (dict1.TryGetValue("Bob", out int age))
            //     Console.WriteLine($"Bob age using TryGetValue: {age}");

            // F. Nested Dictionary (dictionary of dictionaries)
            var nestedDict = new Dictionary<string, Dictionary<string, int>>
            {
                ["Group1"] = new Dictionary<string, int> { ["Alice"] = 25, ["Bob"] = 30 },
                ["Group2"] = new Dictionary<string, int> { ["Charlie"] = 35 }
            };
            // Console.WriteLine(nestedDict);
            // Console.WriteLine(string.Join(", ", nestedDict));










            // *** # 4. HashSet<T>. Duplicates are automatically removed
            // A. Using collection initializer
            var set1 = new HashSet<int> { 1, 2, 3, 2 }; // duplicate will be ignored
            // Console.WriteLine(set1);
            // Console.WriteLine(string.Join(", ", set1));

            // B. Empty HashSet, then add items
            var set2 = new HashSet<string>();
            set2.Add("apple"); // .Add() returns true if added, false if it already exists
            set2.Add("banana"); // .Add() returns true if added, false if it already exists
            set2.Add("apple");  // duplicate will be ignored
            // Console.WriteLine(set2);
            // Console.WriteLine(string.Join(", ", set2));

            // C. From another collection (like array)
            var set3 = new HashSet<int>(arr); // duplicate will be ignored
            // Console.WriteLine(set3);
            // Console.WriteLine(string.Join(", ", set3));

            // D. Set operations
            var setA = new HashSet<int> { 1, 2, 3, 4 };
            var setB = new HashSet<int> { 3, 4, 5, 6 };

            // Union. Combines all elements from both sets | Removes duplicates automatically.
            var union = new HashSet<int>(setA);
            union.UnionWith(setB);
            // Console.WriteLine(union);
            // Console.WriteLine(string.Join(", ", union));

            // Intersect. Keeps only elements that exist in both sets
            var intersect = new HashSet<int>(setA);
            intersect.IntersectWith(setB);
            // Console.WriteLine(intersect);
            // Console.WriteLine(string.Join(", ", intersect));

            // Except. Removes all elements from setA that exist in setB
            var except = new HashSet<int>(setA);
            except.ExceptWith(setB);
            // Console.WriteLine(except);
            // Console.WriteLine(string.Join(", ", except));










            // *** # 5. SortedSet<T>. Duplicates are automatically removed. | Sorted Automatically.

            // A. Using collection initializer
            var sortedSet1 = new SortedSet<int> { 5, 1, 3, 2, 2, 4 };
            // Console.WriteLine(sortedSet1);
            // Console.WriteLine(string.Join(", ", sortedSet1));

            // B. Empty SortedSet, then add items
            var sortedSet2 = new SortedSet<string>();
            sortedSet2.Add("banana");
            sortedSet2.Add("apple");
            sortedSet2.Add("banana");
            // Console.WriteLine(sortedSet2);
            // Console.WriteLine(string.Join(", ", sortedSet2));

            // C. From another collection (like array)
            int[] actualArr = [10, 5, 7, 5];
            var sortedSet3 = new SortedSet<int>(actualArr);
            // Console.WriteLine(sortedSet3);
            // Console.WriteLine(string.Join(", ", sortedSet3));

            // D. Min and Max
            // Console.WriteLine("Min: " + sortedSet3.Min);
            // Console.WriteLine("Max: " + sortedSet3.Max);

            // E. Range view (subset between 3 and 7)
            var numbers = new SortedSet<int> { 1, 3, 5, 7, 9 };
            var view = numbers.GetViewBetween(3, 7);
            // Console.WriteLine(view);
            // Console.WriteLine(string.Join(", ", view));

            // F. Set operations (same as HashSet)
            var sortedSetA = new SortedSet<int> { 1, 2, 3, 4 };
            var sortedSetB = new SortedSet<int> { 3, 4, 5, 6 };

            // Union
            var sortedUnion = new SortedSet<int>(sortedSetA);
            sortedUnion.UnionWith(sortedSetB);
            // Console.WriteLine(sortedUnion);
            // Console.WriteLine(string.Join(", ", sortedUnion));

            // Intersect
            var sortedIntersect = new SortedSet<int>(sortedSetA);
            sortedIntersect.IntersectWith(sortedSetB);
            // Console.WriteLine(sortedIntersect);
            // Console.WriteLine(string.Join(", ", sortedIntersect));

            // Except
            var sortedExcept = new SortedSet<int>(sortedSetA);
            sortedExcept.ExceptWith(sortedSetB);
            // Console.WriteLine(sortedExcept);
            // Console.WriteLine(string.Join(", ", sortedExcept));










            // *** # 6. Queue<T>. FIFO (First In, First Out) - like standing in a line. 

            // A. Empty Queue, then Enqueue items
            var queue1 = new Queue<string>();
            queue1.Enqueue("first");
            queue1.Enqueue("second");
            queue1.Enqueue("third");

            // Console.WriteLine("Queue1: " + string.Join(", ", queue1));
            // Console.WriteLine("Dequeue (removes front): " + queue1.Dequeue());
            // Console.WriteLine("Peek (see front without removing): " + queue1.Peek());

            // B. Using collection initializer (C# doesn’t have direct initializer for Queue so we build from IEnumerable). 
            var queue2 = new Queue<int>([1, 2, 3]);
            // Console.WriteLine(queue2);
            // Console.WriteLine(string.Join(", ", queue2));

            // C. Convert from List
            var list = new List<string> { "apple", "banana", "cherry" };
            var queue3 = new Queue<string>(list);
            // Console.WriteLine(queue3);
            // Console.WriteLine(string.Join(", ", queue3));

            // D. Iterating a Queue (foreach keeps order FIFO)
            foreach (var item in queue3)
            {
                // Console.WriteLine(item);
            }

            // E. Clearing a Queue
            queue3.Clear();
            // Console.WriteLine(queue3);
            // Console.WriteLine(string.Join(", ", queue3));










            // *** # 7. Stack<T>. LIFO (Last In, First Out) - like a stack of plates.

            // A. Empty Stack, then Push items
            var stack1 = new Stack<string>();
            stack1.Push("A");
            stack1.Push("B");
            stack1.Push("C");

            // Console.WriteLine("Stack1: " + string.Join(", ", stack1));
            // Console.WriteLine("Pop (removes top): " + stack1.Pop());
            // Console.WriteLine("Peek (see top without removing): " + stack1.Peek());

            // B. Using collection initializer (C# doesn’t have direct initializer for Stack so we build from IEnumerable).
            var stack2 = new Stack<int>([1, 2, 3]);
            // Console.WriteLine(queue2);
            // Console.WriteLine(string.Join(", ", queue2));

            // C. Convert from List
            var stackList = new List<string> { "apple", "banana", "cherry" };
            var stack3 = new Stack<string>(stackList);
            // Console.WriteLine(stack3);
            // Console.WriteLine(string.Join(", ", stack3));

            // D. Iterating a Stack (foreach shows items in LIFO order)
            foreach (var item in stack3)
            {
                // Console.WriteLine(item);
            }

            // E. Clearing a Stack
            stack3.Clear();
            Console.WriteLine(stack3);
            Console.WriteLine(string.Join(", ", stack3));


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
