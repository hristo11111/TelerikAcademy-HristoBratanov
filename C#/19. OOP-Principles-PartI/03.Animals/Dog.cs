using System;
using System.Collections.Generic;
using System.Linq;

class Dog : Animal
{

    public override void Sound()
    {
        Console.WriteLine("Bau-bau");
    }

    public Dog()
    {
    }

    public Dog(string name, int age, Sex sex) : this()
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    
}
