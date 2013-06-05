using System;
using System.Linq;

//problem from last year homework. Please do not evaluate.

class StudentsDemo
{
    static void Main()
    {
        PriorityQueue<Student> students = new PriorityQueue<Student>();
        students.Enqueue(new Student("Ivan", 15, true));
        students.Enqueue(new Student("Petkan", 18, false));
        students.Enqueue(new Student("Dragan", 12, true));
        students.Enqueue(new Student("Petrohan", 15, false));
        students.Enqueue(new Student("Minzuhar", 12, true));
        students.Enqueue(new Student("Kichka", 18, false));

        while (students.Count > 0)
        {
            Console.WriteLine(students.Dequeue());
        }
    }
}
