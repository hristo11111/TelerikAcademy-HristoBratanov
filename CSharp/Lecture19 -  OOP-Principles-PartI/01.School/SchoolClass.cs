using System;
using System.Collections.Generic;
using System.Linq;

class SchoolClass: ICommentable
{
    private string uniqueIdent;
    List<Teacher> teachers = new List<Teacher>();
    public string schoolClassComment { get; set; }

    public string UniqueIdent
    {
        get
        {
            return this.uniqueIdent;
        }
    }

    public void Comment()
    {
        this.schoolClassComment = Console.ReadLine();
    }
}
