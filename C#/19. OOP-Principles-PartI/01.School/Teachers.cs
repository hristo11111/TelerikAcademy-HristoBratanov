using System;
using System.Collections.Generic;
using System.Linq;

class Teacher : People, ICommentable
{
    public string Name { get; set; }
    List<Discipline> disciplines = new List<Discipline>();
    public string Comments { get; set; }

    public void Comment()
    {
        this.Comments = Console.ReadLine();
    }
}
