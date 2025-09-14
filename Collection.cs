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
        private static void Fruits2_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Item added: {e.NewItems![0]}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Item removed: {e.OldItems![0]}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine($"Item replaced: {e.OldItems![0]} → {e.NewItems![0]}");
                    break;
            }
        }

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
            queue1.Enqueue("A");
            queue1.Enqueue("B");
            queue1.Enqueue("C"); // A-B-C

            // Console.WriteLine("Queue1: " + string.Join(", ", queue1));
            // Console.WriteLine("Dequeue (removes front): " + queue1.Dequeue());
            // Console.WriteLine("Peek (see front without removing): " + queue1.Peek());

            // B. Using collection initializer (C# doesn’t have direct initializer for Queue so we build from IEnumerable). 
            var queue2 = new Queue<int>([1, 2, 3]);
            // Console.WriteLine(queue2);
            // Console.WriteLine(string.Join(", ", queue2));

            // C. Convert from List
            var list = new List<int> { 1, 2, 3 };
            var queue3 = new Queue<int>(list);
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
            stack1.Push("C"); // C-B-A

            // Console.WriteLine("Stack1: " + string.Join(", ", stack1));
            // Console.WriteLine("Pop (removes top): " + stack1.Pop());
            // Console.WriteLine("Stack1: " + string.Join(", ", stack1));
            // Console.WriteLine("Peek (see top without removing): " + stack1.Peek());

            // B. Using collection initializer (C# doesn’t have direct initializer for Stack so we build from IEnumerable).
            var stack2 = new Stack<int>([1, 2, 3]);
            stack2.Push(4); // 4-3-2-1
            stack2.Pop();
            // Console.WriteLine(stack2);
            // Console.WriteLine(string.Join(", ", stack2));

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
            // Console.WriteLine(stack3);
            // Console.WriteLine(string.Join(", ", stack3));










            // *** # 8. LinkedList<T>. Doubly-linked list: nodes connected forward & backward.

            // A. Empty LinkedList, then Add items
            var linkedList1 = new LinkedList<int>();
            linkedList1.AddLast(10);   // tail
            linkedList1.AddLast(20);
            linkedList1.AddFirst(5);   // head
            // Console.WriteLine(linkedList1);
            // Console.WriteLine(string.Join(", ", linkedList1));

            // B. Using collection initializer (not directly supported, but can use IEnumerable)
            var linkedList2 = new LinkedList<string>(["apple", "banana", "cherry"]);
            // Console.WriteLine(linkedList2);
            // Console.WriteLine(string.Join(", ", linkedList2));

            // C. Insert after/before a specific node
            var node = linkedList1.Find(10);
            if (node != null)
            {
                linkedList1.AddAfter(node, 15);
                linkedList1.AddBefore(node, 8);
            }
            // Console.WriteLine(linkedList1);
            // Console.WriteLine("LinkedList1 after inserts: " + string.Join(", ", linkedList1));

            // D. Remove elements
            linkedList1.Remove(20);
            linkedList1.RemoveFirst();
            linkedList1.RemoveLast();
            // Console.WriteLine(linkedList1);
            // Console.WriteLine("LinkedList1 after removes: " + string.Join(", ", linkedList1));

            // E. Iterating forward and backward
            foreach (var item in linkedList2)
            {
                // Console.WriteLine(item);
            }

            for (var n = linkedList2.Last; n != null; n = n.Previous)
            {
                // Console.WriteLine(n);
            }










            // *** # 9. SortedList<TKey, TValue>. Key-value pairs sorted by key, best for small datasets.

            // A. Using collection initializer
            var sortedList1 = new SortedList<int, string>
            {
                [2] = "two",
                [1] = "one",
                [3] = "three"
            };
            // Console.WriteLine(string.Join(", ", sortedList1));
            foreach (var item in sortedList1)
            {
                // Console.WriteLine(item);
            }

            // B. Empty SortedList, then Add items
            var sortedList2 = new SortedList<string, int>();
            sortedList2.Add("cherry", 10);
            sortedList2.Add("banana", 20);
            sortedList2.Add("apple", 15);
            // Console.WriteLine(sortedList2);
            // Console.WriteLine(string.Join(", ", sortedList2));

            // C. Access values by key
            // Console.WriteLine("Value for 'banana': " + sortedList2["banana"]);

            // D. Remove items
            sortedList2.Remove("apple");
            sortedList2.RemoveAt(0);
            // Console.WriteLine(sortedList2);
            foreach (var item in sortedList2)
            {
                // Console.WriteLine(item);
            }

            // E. Keys and Values collections
            // Console.WriteLine("Keys: " + string.Join(", ", sortedList1.Keys));
            // Console.WriteLine("Values: " + string.Join(", ", sortedList1.Values));










            // *** # 10. SortedDictionary<TKey, TValue>. Key-value pairs sorted by key, better for larger datasets.

            // A. Using collection initializer
            var sortedDict1 = new SortedDictionary<int, string>
            {
                [3] = "three",
                [1] = "one",
                [2] = "two"
            };
            // Console.WriteLine(string.Join(", ", sortedDict1));
            foreach (var item in sortedDict1)
            {
                // Console.WriteLine(item);
            }

            // B. Empty SortedDictionary, then Add items
            var sortedDict2 = new SortedDictionary<string, int>();
            sortedDict2.Add("cherry", 10);
            sortedDict2.Add("banana", 20);
            sortedDict2.Add("apple", 15);
            // Console.WriteLine(sortedDict2);
            // Console.WriteLine(string.Join(", ", sortedDict2));

            // C. Access values by key
            // Console.WriteLine("Value for 'banana': " + sortedDict2["banana"]);

            // D. Remove items
            sortedDict2.Remove("apple");
            // sortedDict2.RemoveAt(0);  // N/A
            // Console.WriteLine(sortedDict2);
            foreach (var item in sortedDict2)
            {
                // Console.WriteLine(item);
            }


            // E. Keys and Values collections
            // Console.WriteLine("Keys: " + string.Join(", ", sortedDict1.Keys));
            // Console.WriteLine("Values: " + string.Join(", ", sortedDict1.Values));










            // *** # 11. ConcurrentDictionary<TKey, TValue>. Thread-safe dictionary for multi-threaded applications. | Unlike Dictionary, multiple threads can safely read/write at the same time.

            // A. Empty ConcurrentDictionary, then TryAdd items
            var concurrentDict1 = new ConcurrentDictionary<string, int>();
            concurrentDict1.TryAdd("Alice", 25);
            concurrentDict1.TryAdd("Bob", 30);
            // Console.WriteLine(concurrentDict1);
            // Console.WriteLine(string.Join(", ", concurrentDict1));

            // B. Using collection initializer (indirect via IEnumerable of KeyValuePair)
            var initData = new List<KeyValuePair<string, int>>
            {
                new("USA", 1),
                new("France", 2)
            };

            var concurrentDict2 = new ConcurrentDictionary<string, int>(initData);
            // Console.WriteLine(concurrentDict2);
            // Console.WriteLine(string.Join(", ", concurrentDict2));

            // C. AddOrUpdate (safe way to insert/update)
            concurrentDict1.AddOrUpdate("Alice", 1, (key, oldValue) => oldValue + 100);
            concurrentDict1.AddOrUpdate("Charlie", 200, (key, oldValue) => oldValue);
            // Console.WriteLine(concurrentDict1);
            // Console.WriteLine(string.Join(", ", concurrentDict1));

            // D. GetOrAdd
            int val = concurrentDict1.GetOrAdd("Rum", 100);
            // Console.WriteLine(concurrentDict1);
            // Console.WriteLine(string.Join(", ", concurrentDict1));

            // E. Remove (TryRemove)
            if (concurrentDict1.TryRemove("Rum", out var removedValue))
            {
                // Console.WriteLine($"Removed Rum with value {removedValue}");
            }


            // F. Iterating (safe snapshot while iterating)
            foreach (var item in concurrentDict1)
            {
                // Console.WriteLine(item);
            }










            // *** #12. ImmutableList<T>. Once created, it cannot be modified. | Any add/remove/modification produces a new list instance (Original Untouched)

            // A. Create empty ImmutableList
            var emptyImmutableList = ImmutableList<int>.Empty;
            // Console.WriteLine(emptyImmutableList);

            // B. Create with items (builder style)
            var immutableNumbers = ImmutableList.Create(1, 2, 3);
            // Console.WriteLine(immutableNumbers);
            // Console.WriteLine(string.Join(", ", immutableNumbers));

            // C. Add returns a NEW ImmutableList (original unchanged)
            var newNumbers = immutableNumbers.Add(4);
            // Console.WriteLine(immutableNumbers);
            // Console.WriteLine(string.Join(", ", immutableNumbers));
            // Console.WriteLine(newNumbers);
            // Console.WriteLine(string.Join(", ", newNumbers));

            // D. AddRange
            var moreNumbers = immutableNumbers.AddRange([5, 6]);
            // Console.WriteLine(immutableNumbers);
            // Console.WriteLine(string.Join(", ", immutableNumbers));
            // Console.WriteLine(moreNumbers);
            // Console.WriteLine(string.Join(", ", moreNumbers));

            // E. Remove also returns a NEW ImmutableList
            var removed = immutableNumbers.Remove(2);
            // Console.WriteLine(immutableNumbers);
            // Console.WriteLine(string.Join(", ", immutableNumbers));
            // Console.WriteLine(removed);
            // Console.WriteLine(string.Join(", ", removed));

            // F. Replace an item
            var replaced = immutableNumbers.Replace(3, 99);
            // Console.WriteLine(immutableNumbers);
            // Console.WriteLine(string.Join(", ", immutableNumbers));
            // Console.WriteLine(replaced);
            // Console.WriteLine(string.Join(", ", replaced));

            // G. Indexing works like normal List
            // Console.WriteLine("First element: " + immutableNumbers[0]);

            // H. Iteration
            foreach (var item in immutableNumbers)
            {
                // Console.WriteLine(item);
            }









            // *** #13. ImmutableDictionary<TKey, TValue>. Thread-safe key-value store that cannot be modified after creation. | Any add/remove/update returns a NEW dictionary (Original Untouched).

            // A. Create empty ImmutableDictionary
            var emptyDict = ImmutableDictionary<string, int>.Empty;

            // B. Create with initial items
            var dict = ImmutableDictionary.CreateRange(
            [
                new KeyValuePair<string,int>("Alice", 25),
                new KeyValuePair<string,int>("Bob", 30)
            ]);

            foreach (var item in dict)
            {
                // Console.WriteLine(item);
            }

            // C. Add returns a NEW ImmutableDictionary
            var newDict = dict.Add("Charlie", 40);
            foreach (var item in dict)
            {
                // Console.WriteLine(item);
            }

            foreach (var item in newDict)
            {
                // Console.WriteLine(item);
            }

            // D. AddRange
            var moreDict = dict.AddRange(new Dictionary<string, int> { { "David", 50 }, { "Eve", 60 } });
            foreach (var item in moreDict)
            {
                // Console.WriteLine(item);
            }

            // E. Remove returns a NEW ImmutableDictionary
            var removedDict = moreDict.Remove("Bob");
            foreach (var item in removedDict)
            {
                // Console.WriteLine(item);
            }

            // F. SetItem (updates a key, returns a new dictionary)
            var updated = dict.SetItem("Alice", 26);
            foreach (var item in updated)
            {
                // Console.WriteLine(item);
            }

            // G. TryGetValue
            if (dict.TryGetValue("Alice", out var age))
            {
                // Console.WriteLine(age);
            }









            // *** #14. ObservableCollection<T>. A List<T> that raises an event when items are added/removed/replaced. | Common in WPF/MAUI/WinUI for UI data binding.

            // A. Create with initializer
            var fruits1 = new ObservableCollection<string> { "Apple", "Banana" };

            // B. Empty, then add items
            var fruits2 = new ObservableCollection<string>
            {
                "Orange",
                "Mango"
            };

            // C. Attach event handler to listen for changes
            fruits2.CollectionChanged += Fruits2_CollectionChanged;

            // fruits2.Add("Grapes"); // Event is Triggered.
            // fruits2.Remove("Orange"); // Event is Triggered.
            // fruits2[0] = "Kiwi"; // Event is Triggered.

            // Console.WriteLine(fruits2);
            // Console.WriteLine(string.Join(", ", fruits2));









            // *** #15. ConcurrentBag<T>. A thread-safe, unordered collection (like a sack). | Great for multi-threaded producer-consumer scenarios where order doesn't matter.

            // A. Create and add items (single-threaded)
            var bag1 = new ConcurrentBag<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            // Console.WriteLine(bag1);
            // Console.WriteLine(string.Join(", ", bag1));

            // B. TryTake (removes an item) & TryPeek (views item without removing)
            if (bag1.TryTake(out int removedFromBag))
            {
                // Console.WriteLine($"Removed: {removedFromBag}");
            }

            if (bag1.TryPeek(out int peek))
            {
                // Console.WriteLine($"Peeked: {peek}");
            }


            // C. Multi-threaded add
            var bag2 = new ConcurrentBag<int>();
            Parallel.For(0, 10, i => bag2.Add(i));
            // Console.WriteLine(bag2);
            // Console.WriteLine(string.Join(", ", bag2));

            // D. Multi-threaded take
            int totalRemoved = 0;
            Parallel.For(0, 5, _ =>
            {
                if (bag2.TryTake(out int item))
                    Interlocked.Add(ref totalRemoved, 1);
            });

            // Console.WriteLine($"Removed {totalRemoved} items in parallel.");
            // Console.WriteLine("Remaining in Bag2: " + string.Join(", ", bag2));
            // Console.WriteLine(bag2);
            // Console.WriteLine(string.Join(", ", bag2));









            // *** #16. BitArray. A compact collection of bit values (true/false), stored as bits (very memory-efficient). | Great for flags, masks, or large boolean datasets. |  Index-based access

            // A. From a length (all bits default to false)
            var bits1 = new BitArray(8);
            bits1[0] = true;
            bits1[3] = true;

            // Console.WriteLine(bits1);
            // Console.WriteLine("bits1: " + string.Join(", ", bits1.Cast<bool>()));

            // B. From a bool[] array
            bool[] bools = [true, false, true, true];
            var bits2 = new BitArray(bools);

            // Console.WriteLine(bits2);
            // Console.WriteLine("bits2: " + string.Join(", ", bits2.Cast<bool>()));

            // C. From a byte[] (each byte is 8 bits)
            byte[] data = [5];
            var bits3 = new BitArray(data);

            // Console.WriteLine(bits3);
            // Console.WriteLine("bits3: " + string.Join(", ", bits3.Cast<bool>()));

            // D. Bit operations
            var a = new BitArray([true, false, true, false]);
            var b = new BitArray([true, true, false, false]);

            var andResult = a.And(b);
            // For OR, XOR, NOT use: a.Or(b), a.Xor(b), a.Not()
            // Console.WriteLine("AND: " + string.Join(", ", andResult.Cast<bool>()));









            // *** #17. NameValueCollection. Stores string keys and string values. | Allows multiple values for the SAME key (unlike Dictionary). | Maintains the order of keys as added.

            // A. Create and add items
            var nvc1 = new NameValueCollection();
            nvc1.Add("color", "red");
            nvc1.Add("color", "blue");
            nvc1.Add("shape", "circle");

            foreach (string key in nvc1)
            {
                // Console.WriteLine(key);
            }

            // B. Retrieve values
            // string single = nvc1["color"];
            // string[] allColors = nvc1.GetValues("color");

            // C. Modify or remove
            nvc1.Set("color", "green");
            nvc1.Remove("shape");
            foreach (string key in nvc1)
            {
                // Console.WriteLine($"{key}: {nvc1[key]}");
            }

            // D. Other methods
            // Console.WriteLine(nvc1.Count);
            // Console.WriteLine(nvc1.HasKeys());









            // *** #18. ConcurrentStack<T>. A thread-safe LIFO (Last In First Out) collection. | Multiple threads can push/pop simultaneously without locks.

            // A. Create and add items (single-threaded)
            var concurrentStack1 = new ConcurrentStack<int>();
            concurrentStack1.Push(1);
            concurrentStack1.Push(2);
            concurrentStack1.Push(3);

            // Console.WriteLine(concurrentStack1);
            // Console.WriteLine(string.Join(", ", concurrentStack1));

            // B. Pop items
            if (concurrentStack1.TryPop(out int myPopped))
            {
                // Console.WriteLine($"Popped: {myPopped}");
            }

            if (concurrentStack1.TryPeek(out int peeked))
            {
                // Console.WriteLine($"Peeked: {peek} (top of stack without removing)");
            }


            // C. PushRange / PopRange
            var concurrentStack2 = new ConcurrentStack<int>();
            concurrentStack2.PushRange([10, 20, 30]);

            // Console.WriteLine(concurrentStack2);
            // Console.WriteLine(string.Join(", ", concurrentStack2));

            int[] poppedRange = new int[2];
            int poppedCount = concurrentStack2.TryPopRange(poppedRange);
            // Console.WriteLine($"Popped {poppedCount} items: " + string.Join(", ", poppedRange));

            // D. Multi-threaded operations
            var concurrentStack3 = new ConcurrentStack<int>();
            Parallel.For(0, 5, i => concurrentStack3.Push(i));
            int totalPopped = 0;
            Parallel.For(0, 5, i =>
            {
                if (concurrentStack3.TryPop(out _))
                    Interlocked.Increment(ref totalPopped);
            });
            // Console.WriteLine($"Popped {totalPopped} items concurrently.");









            // *** #19. BlockingCollection<T>. A thread-safe producer/consumer collection that can BLOCK. | When adding to a full collection or taking from an empty one. | Ideal for producer-consumer scenarios with backpressure.

            // A. Basic usage with default underlying collection (ConcurrentQueue<T>)
            using var collection = new BlockingCollection<int>(boundedCapacity: 5);

            // Producer Task
            var producer = Task.Run(() =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    collection.Add(i);
                    // Console.WriteLine($"Produced: {i}");
                }
                collection.CompleteAdding();
            });

            // Consumer Task
            var consumer = Task.Run(() =>
            {
                foreach (var myItem in collection.GetConsumingEnumerable())
                {
                    // Console.WriteLine($"Consumed: {myItem}");
                    Thread.Sleep(100);
                }
            });

            Task.WaitAll(producer, consumer);

            // B. TryAdd / TryTake with timeout
            using var bc2 = new BlockingCollection<string>
            {
                "apple"
            };

            if (bc2.TryTake(out string? myItem, TimeSpan.FromMilliseconds(500)))
            {
                // Console.WriteLine("Took item: " + myItem);
            }
                

            // C. Different underlying collection (e.g., stack behavior)
            var stackBased = new BlockingCollection<int>(new ConcurrentStack<int>())
            {
                1,
                2
            };

            Console.WriteLine("Stack-based: " + stackBased.Take());
        }
    }
}
