using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortableCollection<int> collection = new SortableCollection<int>(new[] { 34, 12, 11, 312, 86, 14, 5, 88 });

        Console.WriteLine("Collection before sorting:");
        collection.PrintAllItemsOnConsole();
        Console.WriteLine();

        Console.WriteLine("SelectionSorter output:");
        collection.Sort(new SelectionSorter<int>());
        collection.PrintAllItemsOnConsole();
        Console.WriteLine();

        Console.WriteLine("Quicksorter output:");
        collection.Sort(new Quicksorter<int>());
        collection.PrintAllItemsOnConsole();
        Console.WriteLine();

        Console.WriteLine("MergeSorter output:");
        collection.Sort(new MergeSorter<int>());
        collection.PrintAllItemsOnConsole();
        Console.WriteLine();

        Console.WriteLine("Linear search at 86:");
        Console.WriteLine(collection.LinearSearch(86));
        Console.WriteLine();

        Console.WriteLine("Binary search at 14:");
        Console.WriteLine(collection.BinarySearch(14));
        Console.WriteLine();

        Console.WriteLine("Shuffle:");
        collection.Shuffle();
        collection.PrintAllItemsOnConsole();
        Console.WriteLine();
    }
}
