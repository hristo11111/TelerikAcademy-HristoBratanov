using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //statement1
        Potato potato;
        //... 
        if (potato == null)
        {
            throw new ArgumentNullException("object of class Potato is null");
        }
        else
        {
            if (potato.IsPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }
        }

        //statement2
        if (ShouldVisitCell)
        {
            if (XinRange(x, xMin, xMax) && YinRange(y, yMin, yMax))
            {
                VisitCell();
            }

        }
    

        private static bool YinRange(int y, int yMin, int yMax)
        {
            bool yInRange = yMin <= y && y >= yMax;

            return yInRange;
        }

        private static bool XinRange(int x, int xMin, int xMax)
        {
            bool xInRange = xMin <= x && x >= xMax;

            return xInRange;
        }
    }
