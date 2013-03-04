using System;
using System.Collections.Generic;
using System.Linq;

class Frog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Kwak-kwak");
    }

    public Frog()
    {
    }

    public Frog(string name, int age, Sex sex) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }
}
