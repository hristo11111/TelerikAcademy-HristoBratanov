using System;
using System.Linq;

class Tomcat : Cat
{

    public Tomcat()
    {
        this.Sex = Sex.male;
    }

    public Tomcat(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override void Sound()
    {
        Console.WriteLine("MiauMiau");
    }
}

