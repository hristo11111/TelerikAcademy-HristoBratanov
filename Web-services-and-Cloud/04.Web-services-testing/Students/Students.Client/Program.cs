using Students.Data;
using Students.Data.Migrations;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Students.Client
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsProblemContext, Configuration>());

            Student student1 = new Student()
            {
                FirstName = "Pehso",
                LastName = "Peshev",
                Age = 12,
                Grade = 9,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Value = 5.5M,
                        Subject = "Maths"
                    },
                    new Mark()
                    {
                        Value = 2M,
                        Subject = "Literature"
                    },
                    new Mark()
                    {
                        Value = 4.6M,
                        Subject = "Maths"
                    }
                },
                School = new School()
                {
                    Name = "PMG",
                    Location = "Kaspichan"
                }
            };

            var context = new StudentsProblemContext();
            context.Students.Add(student1);
            context.SaveChanges();
        }
    }
}
