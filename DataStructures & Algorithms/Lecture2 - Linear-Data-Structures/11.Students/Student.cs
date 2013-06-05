using System;
using System.Linq;
using System.Text;

//problem from last year homework. Please do not evaluate.

class Student : IComparable<Student>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public bool PaidSemesterOnline { get; private set; }

    public Student(string name, int age, bool paidSemesterOnline)
    {
        this.Name = name;
        this.Age = age;
        this.PaidSemesterOnline = paidSemesterOnline;
    }
    
    public int CompareTo(Student student)
    {
        return student.PaidSemesterOnline.CompareTo(this.PaidSemesterOnline);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Name: " + this.Name + "\n");
        sb.Append("Age: " + this.Age + "\n");
        sb.Append("Paid: " + this.PaidSemesterOnline + "\n");

        return sb.ToString();
    }
}
