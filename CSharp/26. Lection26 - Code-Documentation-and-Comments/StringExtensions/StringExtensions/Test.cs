using System;
using System.Linq;

namespace Telerik.ILS.Common
{
    class Test
    {
        static void Main()
        {
            var inputLatin = "alabalanica";
            var inputCyrillic = "алабаланица";
            var fileExtension = "jpg";
            inputLatin.ToLower();
            Console.WriteLine(inputLatin.ToMd5Hash());
            Console.WriteLine(inputLatin.ToBoolean());
            Console.WriteLine(inputLatin.ToShort());
            Console.WriteLine(inputLatin.ToInteger());
            Console.WriteLine(inputLatin.ToLong());
            Console.WriteLine(inputLatin.ToDateTime());
            Console.WriteLine(inputLatin.CapitalizeFirstLetter());
            Console.WriteLine(inputLatin.GetStringBetween("ala", "nica"));
            Console.WriteLine(inputLatin.ConvertLatinToCyrillicKeyboard());
            Console.WriteLine(inputCyrillic.ConvertCyrillicToLatinLetters());
            Console.WriteLine(inputLatin.ToValidUsername());
            Console.WriteLine(inputLatin.GetFirstCharacters(5));
            Console.WriteLine(fileExtension.ToContentType());
            var bytesArray = inputLatin.ToByteArray();
            for (int i = 0; i < bytesArray.Length; i++)
            {
                Console.WriteLine(bytesArray[i]);
            }
            
        }
    }
}
