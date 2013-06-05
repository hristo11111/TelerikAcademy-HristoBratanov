using System;
using System.Linq;

class File
{
    private string name;
    private int size;

    public File(string name, int size)
    {
        this.Name = name;
        this.Size = size;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Size
    {
        get { return this.size; }
        set { this.size = value; }
    }
}
