using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";

                default: throw new ArgumentException("The number is invalid!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("There is not any parameters entered!");
            }

            int max = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        static void PrintNumberWithFixedPoint(double number, int digits)
        {
            string format = "{0:F" + digits + "}";

            Console.WriteLine(format, number);
        }

        static void PrintNumberInPercentage(double number)
        {
            string format = "{0:P}";

            Console.WriteLine(format, number);
        }

        static void PrintNumberAligned(object number, int alignChars)
        {
            string format = "{0," + alignChars + "}";

            Console.WriteLine(format, number);
        }
        
        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("The both points have equal coordinates.");
            }

            bool position = y1 == y2;
            
            return position;
        }

        static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("The both points have equal coordinates.");
            }

            bool position = x1 == x2;
            
            return position;
        }

        static void Main()
        {
            PrintNumberAligned(45, 8);
            PrintNumberWithFixedPoint(45, 5);
            PrintNumberInPercentage(125);

            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            
            Console.WriteLine("Horizontal? " + IsHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
