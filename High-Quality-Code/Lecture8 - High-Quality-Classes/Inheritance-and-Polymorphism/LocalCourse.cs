using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab) : 
            base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public LocalCourse(string courseName)
            : this(courseName, null, null, null)
        {
        }

        public LocalCourse(string courseName, string teacherName) : 
            this(courseName, teacherName, null, null)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students) : 
            this(courseName, teacherName, students, null)
        {
        }

        public override string ToString()
        {
            if (this.Lab != null)
            {
                return base.ToString() + "; Lab = " + this.Lab + " }";
            }

	        return base.ToString();
        }
        
    }
}
