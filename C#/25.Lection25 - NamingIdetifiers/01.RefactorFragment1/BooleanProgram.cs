using System;
using System.Linq;

class BooleanProgram
{
    class BooleanClass
    {
        public void ToString(bool value)
        {
            string valueToString = value.ToString();
            Console.WriteLine(valueToString);
        }
    }

    public static void Main()
    {
        BooleanClass boolClassObject = new BooleanClass();
        boolClassObject.ToString(true);
    }
}

