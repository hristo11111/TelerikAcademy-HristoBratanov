using System;
using System.Collections.Generic;

class Encrypt
{
    static void Main()
    {
        Console.Write("string to encode: ");
        string input = Console.ReadLine();
        Console.Write("string to decode: ");
        string cipher = Console.ReadLine();
        List<char> encoded = new List<char>();
        int cipherIndex = 0;
        int lastCipherIndex = cipher.Length - 1;
        for (int i = 0; i < input.Length; i++)
        {
            char element = (char)(input[i] ^ cipher[cipherIndex]);
            cipherIndex++;
            if (cipherIndex > lastCipherIndex)
            {
                cipherIndex = 0;
            }

            encoded.Add(element);
        }

        Console.WriteLine("encoded: " + String.Concat(encoded));

        List<char> decoded = new List<char>();
        cipherIndex = 0;
        for (int i = 0; i < encoded.Count; i++)
        {
            char element = (char)(encoded[i] ^ cipher[cipherIndex]);
            cipherIndex++;
            if (cipherIndex > lastCipherIndex)
            {
                cipherIndex = 0;
            }

            decoded.Add(element);
        }

        Console.WriteLine("decoded: " + String.Concat(decoded));
    }

}
