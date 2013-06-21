using System;
using System.Linq;

class Program
{
    static void Main()
    {
        BiDictionary<string, string, int> people =
            new BiDictionary<string, string, int>(true);
        people.AddItem("Gosho", "Bozhilov", 15);
        people.AddItem("Matey", "Kaziiski", 15);
        people.AddItem("Ivan", "Kaziiski", 17);
        people.AddItem("Ivan", "Petrov", 55);
        people.AddItem("Ivan", "Kaziiski", 12);

        var bykey1 = people.GetElementsByKey1("Ivan");
        foreach (var item in bykey1)
        {
            Console.WriteLine(item.key1 + " " + item.key2 + ", age: " + item.value);
        }

        Console.WriteLine("-------------------------");

        var bykey2 = people.GetElementsByKey2("Kaziiski");
        foreach (var item in bykey2)
        {
            Console.WriteLine(item.key1 + " " + item.key2 + ", age: " + item.value);
        }

        Console.WriteLine("-------------------------");

        var bykey1and2 = people.GetElementsByKey1AndKey2("Ivan", "Kaziiski");

        foreach (var item in bykey1and2)
        {
            Console.WriteLine(item.key1 + " " + item.key2 + ", age: " + item.value);
        }
    }
}
