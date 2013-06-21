using System;
using System.Linq;

class TestHashSet
{
    static void Main()
    {
        HashedSet<int> hashSet1 = new HashedSet<int>();

        for (int i = 0; i < 10; i++)
        {
            hashSet1.Add(i);
        }

        Console.WriteLine("Find element with key = 4");
        Console.WriteLine(hashSet1.Find(4));

        Console.WriteLine("Find element with key = 2 and write the count of elements");
        hashSet1.Remove(2);
        Console.WriteLine(hashSet1.Count);

        HashedSet<int> hashSet2 = new HashedSet<int>();
        hashSet2.Add(5);
        hashSet2.Add(9);
        hashSet2.Add(33);

        Console.WriteLine("Union: ");
        hashSet1.UnionWith(hashSet2);
        for (int i = 0; i < hashSet1.Container.Count; i++)
        {
            Console.WriteLine(hashSet1.Container.Keys[i]);
        }
        Console.WriteLine();

        Console.WriteLine("Intersect: ");
        hashSet1.IntersectWith(hashSet2);

        for (int i = 0; i < hashSet1.Container.Count; i++)
        {
            Console.WriteLine(hashSet1.Container.Keys[i]);
        }
        Console.WriteLine();

        Console.WriteLine("count after clear");
        hashSet2.Clear();
        Console.WriteLine(hashSet2.Container.Count);
    }
}
