using System;

class SqrtInteger
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        try
        {
            int num = Int32.Parse(s);
            CheckForNegativeNumbers(num);
            Console.WriteLine(Math.Sqrt(num));
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }

        catch (OverflowException)
        {
            Console.WriteLine("Invalid number");
        }

        catch (System.ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number");
        }

        finally
        {
            Console.WriteLine("Good bye");
        }

    }

    static void CheckForNegativeNumbers(int num)
    {
        if (num < 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }
        
    }
}
