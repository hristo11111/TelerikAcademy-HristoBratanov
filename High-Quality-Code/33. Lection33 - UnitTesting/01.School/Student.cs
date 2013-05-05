using System;
using System.Linq;

public class Student
{
    private const int MIN_ID = 10000;
    private const int MAX_ID = 99999;

    private string name;
    private int studentNumber;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The student's name cannot be null or empty!");
            }

            this.name = value;
        }
    }

    public int StudentNumber
    {
        get { return this.studentNumber; }
        set
        {
            if (value < MIN_ID || MAX_ID < value)
            {
                throw new ArgumentException("The student's ID number cannot be less than 10000" + 
                " and more than 99999!");
            }

            this.studentNumber = value;
        }
    }

    public Student(string name, int studentNumber)
    {
        this.Name = name;
        this.StudentNumber = studentNumber;
    }
}
