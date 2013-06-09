//Write a program that reads N integers from the console and reverses them using a stack. 
//Use the Stack<int> class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReverseSequenceViaStack
{
    static void Main(string[] args)
    {
        Stack<int> sequence = new Stack<int>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "")
            {
                Console.WriteLine("End sequence!\n");
                break;
            }
            else
            {
                int number = int.Parse(command);
                sequence.Push(number);
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("Reversed sequence is: \n");
        Stack<int> reversed = new Stack<int>();
        while (sequence.Count > 0)
        {
            int element = sequence.Pop();
            sb.Append(element + " ");
            reversed.Push(element);
        }

        Console.WriteLine(sb.ToString());
    }
}
