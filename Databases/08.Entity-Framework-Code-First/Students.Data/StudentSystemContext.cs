using System;
using System.Linq;
using System.Data.Entity;
using StudentsModel;

namespace Students.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentDb")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
