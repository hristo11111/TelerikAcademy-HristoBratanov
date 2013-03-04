using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Student firstStud = new Student("Petyr", "Petrov", 2);
        Student secondStud = new Student("Ivanka", "Hristova", 5);
        Student thirdStud = new Student("Ivan", "Dimkov", 6);
        Student forthStud = new Student("Hristo", "Petrunov", 5);
        Student fifthStud = new Student("Lubomir", "Ivanov", 4);
        Student sixthStud = new Student("Zahari", "Petrov", 3);
        Student seventhStud = new Student("Pencho", "Butilkov", 5);
        Student eightStud = new Student("Reni", "Shamandurova", 2);
        Student ninthStud = new Student("Ani", "Zaspalova", 6);
        Student tenthStud = new Student("Geri", "Otkachalkova", 6);

        List<Student> students = new List<Student>() { firstStud, secondStud, thirdStud, forthStud, fifthStud, sixthStud, secondStud, eightStud, ninthStud, tenthStud };

        var studentsQuery =
            from student in students
            orderby student.Grade
            select student;

        foreach (var item in studentsQuery)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        Worker firstWorker = new Worker("Petyr", "Petrov", 50, 8);
        Worker secondWorker = new Worker("Ivanka", "Hristova", 68,6);
        Worker thirdWorker = new Worker("Ivan", "Dimkov", 22,2);
        Worker forthWorker = new Worker("Hristo", "Petrunov", 123.5, 4);
        Worker fifthWorker = new Worker("Lubomir", "Ivanov", 4542, 8);
        Worker sixthWorker = new Worker("Zahari", "Petrov", 12.3, 5);
        Worker seventhWorker = new Worker("Pencho", "Butilkov", 1234, 4);
        Worker eightWorker = new Worker("Reni", "Shamandurova", 8745, 11);
        Worker ninthWorker = new Worker("Ani", "Zaspalova", 214, 5);
        Worker tenthWorker = new Worker("Geri", "Otkachalkova", 6, 1);
        List<Worker> workers = new List<Worker>() { firstWorker, secondWorker, thirdWorker, forthWorker, fifthWorker, sixthWorker, seventhWorker, eightWorker, ninthWorker, tenthWorker };

        var workersQuery =
            from worker in workers
            orderby worker.MoneyPerHour(worker.WeekSalary, worker.WorkHoursPerDay)
            select worker;

        foreach (var item in workersQuery)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        List<Human> humans = new List<Human>();
        foreach (var item in workers)
        {
            humans.Add(item);
        }
        foreach (var item in students)
        {
            humans.Add(item);
        }

        var sortedHuman =
            from human in humans
            orderby human.FirstName, human.LastName
            select human;

        foreach (var item in sortedHuman)
        {
            Console.WriteLine(item);
        }
    }
}
