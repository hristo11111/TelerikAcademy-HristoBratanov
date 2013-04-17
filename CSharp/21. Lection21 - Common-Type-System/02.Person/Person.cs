using System;

class Person
{
    public string Name { get; set; }
    public byte? Age { get; set; }

    public Person(string name, byte? age = null)
    {
        this.Name = name;
        this.Age = age;
    }


    public override string ToString()
    {
        if (this.Age == null)
        {
            return string.Format("Student:\nName: {0}\nAge: Unspecified", this.Name);
        }
        else
        {
            return string.Format("Student:\nName: {0}\nAge: {1}", this.Name, this.Age);
        }
    }
}

