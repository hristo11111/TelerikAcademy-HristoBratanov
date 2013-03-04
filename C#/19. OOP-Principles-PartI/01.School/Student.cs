using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student : People, ICommentable
{
    public string Name { get; set; }
    private byte classNumber;
    public string studentComment { get; set; }

    public byte ClassNumber
    {
        get
        {
            return this.classNumber;
        }
    }

    public Student(string name)
    {
        this.Name = name;
    }


    public void Comment()
    {
        this.studentComment = Console.ReadLine();
    }
}
