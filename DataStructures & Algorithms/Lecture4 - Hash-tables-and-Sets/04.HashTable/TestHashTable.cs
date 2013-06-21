using System;
using System.Linq;

class TestHashTable
{
    static void Main()
    {
        HashTable<int, string> hashTable = new HashTable<int, string>();
        for (int i = 0; i < 10; i++)
        {
            hashTable.Add(i, "element: " + i);
        }

        Console.WriteLine(hashTable[5]);

        Console.WriteLine(hashTable.Find(3));

        Console.WriteLine(hashTable.Contain(11));

        hashTable.Remove(7);
        hashTable.Remove(5);
        Console.WriteLine(hashTable.Keys.Count());
    }


}
