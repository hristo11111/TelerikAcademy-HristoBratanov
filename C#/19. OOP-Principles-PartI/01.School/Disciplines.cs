using System;
using System.Linq;

class Discipline : ICommentable
{
    public string Name { get; set; }
    public int NumberOfLectures { get; set; }
    public int NumberOfExercises { get; set; }
    public string disciplineComment { get; set; }

    public void Comment()
    {
        this.disciplineComment = Console.ReadLine();
    }
}

