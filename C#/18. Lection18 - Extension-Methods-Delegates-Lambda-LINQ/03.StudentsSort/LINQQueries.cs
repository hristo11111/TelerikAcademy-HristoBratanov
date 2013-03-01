using System;
using System.Linq;

static class LINQQueries
{
    public static void IsFirstNameBeforeLast(Student[] arr)
    {
        var namesQuery =
            from names in arr
            where names.FirstName.CompareTo(names.LastName) == -1
            select names;

        foreach (var item in namesQuery)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
    }

    public static void IsBetween18_24(Student[] arr)
    {
        var ageQuiery =
            from student in arr
            where student.Age >= 18 && student.Age <= 24
            select student;

        foreach (var item in ageQuiery)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
    }

    public static void OrderBy(Student[] arr)
    {
        var orderQuery =
            from student in arr
            orderby student.FirstName, student.LastName
            select student;

        foreach (var item in orderQuery)
        {
            Console.WriteLine(item.FirstName + " " + item.LastName);
        }
            
    }
}
