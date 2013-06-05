using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SortList
{
    static void Main()
    {
        List<int> sequence = new List<int>();

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
                sequence.Add(number);
            }
        }

        sequence.Sort();
        Console.WriteLine("The sorted sequence is: \n" + SequenceToString(sequence));
    }

    private static string SequenceToString(List<int> sequence)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < sequence.Count; i++)
        {
            sb.Append(sequence[i]);
            if (i != sequence.Count - 1)
            {
                sb.Append(", ");
            }
        }

        return sb.ToString();
    }
}
