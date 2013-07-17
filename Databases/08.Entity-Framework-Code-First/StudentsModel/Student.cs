﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsModel
{
    public class Student
    {
        private ICollection<Homework> homeworks;
        private ICollection<Course> courses;

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public Student()
        {
            this.homeworks = new HashSet<Homework>();
            this.courses = new HashSet<Course>();
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
