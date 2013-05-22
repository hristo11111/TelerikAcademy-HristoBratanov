// 1.Write a method that from a given array of students finds all students 
// whose first name is before its last name alphabetically. Use LINQ query operators.
// 2.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
// 3.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
// by first name and last name in descending order. Rewrite the same with LINQ.


using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Student[] students = {   
                                 new Student("Petyr", "Petrov", 18),
                                 new Student("Anelia", "Terzieva", 24),
                                 new Student("Rusi", "Golemanov", 12),
                                 new Student("Penio", "Peshev", 33),
                                 new Student("Penio", "Penev", 28)
                             };
        Console.WriteLine("first name < last name:");
        LINQQueries.IsFirstNameBeforeLast(students);

        Console.WriteLine();

        Console.WriteLine("between 18 - 24:");
        LINQQueries.IsBetween18_24(students);

        Console.WriteLine();

        var querySort = students.OrderBy(first => first.FirstName).ThenBy(last => last.LastName);
        foreach (var item in querySort)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }

        Console.WriteLine();

        LINQQueries.OrderBy(students);
    }
}