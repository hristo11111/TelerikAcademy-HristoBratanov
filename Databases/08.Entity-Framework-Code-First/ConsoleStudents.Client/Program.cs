using System;
using System.Linq;
using StudentsModel;
using Students.Data;
using System.Data.Entity;
using Students.Data.Migrations;

namespace ConsoleStudents.Client
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            StudentSystemContext db = new StudentSystemContext();

            Student studentPesho = new Student();
            studentPesho.Name = "Pesho";
            studentPesho.Number = 1122;
            
            db.Students.Add(studentPesho);

            Homework homeworkPesho = new Homework();
            homeworkPesho.Content = "1 problem solved by enough for begginer";
            homeworkPesho.TimeSent = new DateTime(2013, 05, 22);
            homeworkPesho.StudentId = 1;
            homeworkPesho.CourseId = 1;

            db.Homeworks.Add(homeworkPesho);

            Course maths = new Course();
            maths.Name = "Maths";
            maths.Description = "Learning mathematics";

            db.Courses.Add(maths);

            studentPesho.Courses.Add(maths);
            maths.Students.Add(studentPesho);

            var nullStudents =
                from stud in db.Students
                where stud.Name == null
                select stud;

            foreach (var item in nullStudents)
            {
                db.Students.Remove(item);
            }

            db.SaveChanges();
        }
    }
}
