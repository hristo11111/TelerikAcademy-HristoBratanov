using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town) :
            base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public OffsiteCourse(string courseName) : 
            this(courseName, null, null, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName) : 
            this(courseName, teacherName, null, null)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students) :
            this(courseName, teacherName, students, null)
        {
        }

        public override string ToString()
        {
            if (this.Town != null)
            {
                return base.ToString() + "; Lab = " + this.Town + " }";
            }

	        return base.ToString();
        }
    }
}
