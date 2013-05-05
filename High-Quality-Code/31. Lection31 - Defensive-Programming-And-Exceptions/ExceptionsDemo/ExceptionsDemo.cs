using System;


// Добавилсъм някои неща и съм преформатирал съобщенията. Да се изчака коментар във форума.
class ExceptionsDemo
{
    static void Main()
    {
        string input = Console.ReadLine();
        try
        {
            Int32.Parse(input);
            Console.WriteLine("You entered valid Int32 number {0}.", input);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("The entered number is not in correct format!", ex);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("The number is not in Int32 range! Please enter integer between {0} and {1}", 
                Int32.MinValue, Int32.MaxValue, ex);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("The entered number is null", ex);
        }
    }
}
