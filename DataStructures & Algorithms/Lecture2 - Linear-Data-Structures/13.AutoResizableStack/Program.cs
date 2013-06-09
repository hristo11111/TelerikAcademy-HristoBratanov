//Implement the ADT stack as auto-resizable array. Resize the capacity on demand 
//(when no space is available to add / insert a new element).

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 1; i < 20; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine(stack.Peek());
        Console.WriteLine();

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        stack.Push(252);
        Console.WriteLine();

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
    }
}
