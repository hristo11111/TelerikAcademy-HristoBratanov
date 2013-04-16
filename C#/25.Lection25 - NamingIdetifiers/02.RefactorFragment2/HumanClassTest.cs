using System;
using System.Linq;

class HumanClassTest
{
    enum Gender
    {
        Male,
        Female
    }

    class Human
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // ssn = Social Security Number
    public void CreateHuman(int ssn)
    {
        Human newHuman = new Human();
        newHuman.Age = ssn;
        if (ssn % 2 == 0)
        {
            newHuman.Name = "BigBrother";
            newHuman.Gender = Gender.Male;
        }
        else
        {
            newHuman.Name = "HotChick";
            newHuman.Gender = Gender.Female;
        }
    }

    static void Main()
    {

    }
}

