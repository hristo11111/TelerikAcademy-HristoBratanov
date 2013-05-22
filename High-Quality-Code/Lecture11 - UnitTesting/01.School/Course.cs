using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    private readonly List<Student> students;
    public string courseName { get; private set; }

    public Course(string name)
    {
        this.courseName = name;
        this.students = new List<Student>();
    }

    public List<Student> Students
    {
        get { return this.students; }
    }

    public void AddStudent(Student student)
    {
        if (this.Students.Count == 30)
        {
            throw new ArgumentOutOfRangeException(
                "The students cannot be more than 30 in course!");
        }

        foreach (Student stud in this.Students)
        {
            if (stud.StudentNumber == student.StudentNumber)
            {
                throw new ArgumentException(
                    "There is already student with this number!");
            }
        }
        this.Students.Add(student);
    }

    public void RemoveStudentByNumber(int studentNumber)
    {
        if (this.Students.Count == 0)
        {
            throw new ArgumentOutOfRangeException(
                "You cannot remove student from empty list of students!");
        }

        bool studentExists = false;
        foreach(var student in this.students)
        {
            if (student.StudentNumber == studentNumber)
	        {
		        this.Students.Remove(student);
                studentExists = true;
                break;
	        }
        }

        if (!studentExists)
        {
            Console.WriteLine(
                "there is no student with this number({0})", studentNumber);
        }
    }
}
