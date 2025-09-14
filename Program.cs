// // Value Types vs Reference Types
// // Value types → store the actual value directly (live on the stack). Integers, Floating-point Numbers, Boolean, Characters, Date and Time, Structs
// // Reference types → store a reference (address) to the actual data (live on the heap). Strings, Objects, Arrays, Collections, 


// // ** Integers
// int age = 30; // 32-bit
// long population = 7000000000; // 64-bit
// short level = 10; // 16-bit
// byte small = 255; // 8-bit

// Console.WriteLine($"Age: {age}, Population: {population}, Level: {level}, Small: {small}");


// // ** Floating-point Numbers
// float pi = 3.14f; // 32-bit
// double price = 99.99; // 64-bit
// decimal salary = 5000.75m; // 128 bit

// Console.WriteLine($"Pi: {pi}, Price: {price}, Salary: {salary}");


// // ** Boolean
// bool isActive = true;
// bool isRemoved = false;

// Console.WriteLine($"Active User: {isActive}, Removed User: {isRemoved}");


// // ** Characters
// char grade = 'B';
// char section = 'A';

// Console.WriteLine($"User Grade: {grade}, User Section: {section}");


// // ** Date and Time
// DateTime now = DateTime.Now;
// DateTime flightDate = new(2025, 12, 25, 15, 30, 0);

// Console.WriteLine($"Current Time: {now}, Flight Date: {flightDate}");


// // ** Structs
// // public struct Point
// // {
// //   public int X { get; set; }
// //   public int Y { get; set; }
// // }


// // ** Strings
// string customerName = "Jahid Hasan Rumman";

// Console.WriteLine($"Customer Name: {customerName}");

// // ** Objects
// object data = "Hello"; // Can store any type
// data = 123;

// Console.WriteLine($"Object can be any data types: {data}");


// // ** Arrays
// int[] scores = [23, 24, 25, 26];
// string[] names = ["Rumman", "Hasan", "Jahid"];

// Console.WriteLine($"Array of Scores: {string.Join(", ", scores)}, Array of Names: {string.Join(", ", names)}");


// // ** Collections
// List<string> products = ["Book", "Pen"];
// Dictionary<int, string> users = new()
// {
//   {
//     1, "Rumman"
//   },
//   {
//     2, "Hasan"
//   }
// };

// Console.WriteLine("Products: " + string.Join(", ", products));


using CollectionDemo;

// Collections.Run();
Console.WriteLine("Hello From Rider");