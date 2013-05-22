using System;

class AstrologicalDigits
{
    static void Main()
    {
      ulong sumOfDigits = 0;
      while (true)
      {
          int ch = Console.Read();
          if (ch == (int)'\n' || ch == (int)'\r' || ch == -1)
          {
              break;
          }
          if (ch >= '0' && ch <= '9')
          {
              ulong digit = (ulong)ch - (ulong)'0';
              sumOfDigits = sumOfDigits + digit;
          }
      }
      while (sumOfDigits > 9)
      {
          ulong sumNextDigits = 0;
          while (sumOfDigits > 0)
          {
              ulong lastDigit = sumOfDigits % 10;
              sumNextDigits = lastDigit + sumNextDigits;
              sumOfDigits = sumOfDigits / 10;              
          }
          sumOfDigits = sumNextDigits;
      }
      Console.WriteLine(sumOfDigits);
    }
}

