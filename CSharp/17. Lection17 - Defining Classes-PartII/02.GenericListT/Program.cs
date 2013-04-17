//1. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.
//2. Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.
//3. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. You may need to add a generic constraints for the type T.


using System;

class Program
{
    static void Main()
    {
        GenericList<int> testList = new GenericList<int>();
        int chislo = 231;
        testList.Add(chislo);
        testList.Add(chislo);
        testList.InsertAtPosition(1, 5);
        testList.InsertAtPosition(1, 5);
        testList.Add(chislo + 9);

        int element = testList[0];
        Console.WriteLine(element);

        testList.RemoveAtIndex(3);

        testList.InsertAtPosition(0, 124);

        //testList.Clear();

        testList.FindElementByValue(421);

        testList.ToStringNew();

        int min = testList.Min();
        Console.WriteLine(min);

        int max = testList.Max();
        Console.WriteLine(max);
    }
}
