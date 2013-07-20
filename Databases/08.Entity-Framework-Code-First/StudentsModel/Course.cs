using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsModel
{
    public class Course
    {
        private ICollection<Homework> homeworks;
        private ICollection<Student> students;

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
