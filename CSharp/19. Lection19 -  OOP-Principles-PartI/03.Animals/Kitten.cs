using System;
using System.Linq;

class Kitten : Cat
{
    public Kitten()
    {
        this.Sex = Sex.female;
    }

    public Kitten(string name, int age) : this()
    {
        this.Name = name;
        this.Age = age;
    }

    public override void Sound()
    {
        Console.WriteLine("Miauuuuuuuu");
    }
}
