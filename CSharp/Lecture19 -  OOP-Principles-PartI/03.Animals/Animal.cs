using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Sex { male, female };

abstract class Animal : ISound
{
    public int Age { get; set; }
    public string Name { get; set; }
    public Sex Sex { get; set; }

    public abstract void Sound();

    public override string ToString()
    {
        return string.Format(this.Name + " " + this.Age + " " + this.Sex);
    }

}
