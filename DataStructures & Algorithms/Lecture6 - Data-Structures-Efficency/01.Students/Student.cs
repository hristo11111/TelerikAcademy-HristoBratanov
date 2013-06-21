using System;
using System.Linq;

class Student
{
    private string course;
    private string firstName;
    private string lastName;

    public Student(string firstName, string lastName, string course)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.course = course;
    }

    public string Course
    {
        get { return this.course; }
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public string LastName
    {
        get { return this.lastName; }
    }
}