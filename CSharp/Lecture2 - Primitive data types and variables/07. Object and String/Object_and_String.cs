using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Object_and_String
{
    static void Main()
    {
        string string1 = "Hello";
        string string2 = "World";
        object string_concat = string1 + " " + string2;
        string obj_to_string = (string)string_concat;
        Console.WriteLine(obj_to_string);
    }
}
