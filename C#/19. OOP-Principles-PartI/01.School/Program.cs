using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Student pesho = new Student("Pesho");
        pesho.Comment();
        Console.WriteLine(pesho.studentComment);
    }
}
