using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    private readonly List<Student> students = new List<Student>();

    public List<Student> Students
    {
        get { return this.students; }
    }

    public void AddStudent(Student student)
    {
        if (this.Students.Count == 30)
        {
            throw new ArgumentOutOfRangeException("The students cannot be more than 30 in course!");
        }
        this.Students.Add(student);
    }

    public void RemoveStudentByNumber(int studentNumber)
    {
        if (this.Students.Count == 0)
        {
            throw new ArgumentOutOfRangeException("You cannot remove student from empty list of students!");
        }

        foreach(var student in this.students)
        {
            if (student.StudentNumber == studentNumber)
	        {
		        this.Students.Remove(student);
                break;
	        }
        }
    }
}
