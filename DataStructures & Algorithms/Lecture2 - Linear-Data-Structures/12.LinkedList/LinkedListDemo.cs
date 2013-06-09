//Implement the data structure linked list. Define a class ListItem<T> that has two fields: 
//value (of type T) and NextItem (of type ListItem<T>). Define additionally 
//a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

using System;
using System.Collections.Generic;
using System.Linq;

class LinkedListDemo
{
    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>();
        list.Add("5");
        list.Add("9");
        list.Add("19");
        list.Add("5");

        Console.WriteLine(list[2]);

        list.Remove(1);
        Console.WriteLine(list[1]);
        int value = list.Remove("5");

        Console.WriteLine(list.Count);

    }
}
