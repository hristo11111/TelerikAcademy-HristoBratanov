using System;
using System.Linq;

class Student : Human
{
    public float Grade { get; set; }

    public Student(string firstName, string lastName, float grade)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Grade = grade;
    }

    public override string ToString()
    {
        return string.Format(this.FirstName + " " + this.LastName + " " + "grade: " + this.Grade);
    }
}